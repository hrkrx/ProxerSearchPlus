using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using ProxerSearchPlus.Api.Caching;
using ProxerSearchPlus.Api.Model.Proxer.v1;

namespace ProxerSearchPlus.Api.Caching.Database.MongoDB
{
    public class MongoDBConnector : IDatabaseConnection
    {

        private static MongoClient client;

        public MongoDBConnector(string connection)
        {
            if(client == null)
            {
                client = new MongoClient(connection);
            }
        }

        public MongoDBConnector()
        {
            if(client == null)
            {
                var dbConnectionString = File.ReadAllText("database.credentials");
                client = new MongoClient(dbConnectionString);
            }
        }

        public IMongoDatabase GetDatabase()
        {
            return client.GetDatabase("ProxerSearchPlus");
        }


        public bool Put(object entry)
        {
            try
            {
                var properties = entry.GetType().GetProperties();
                var idColumn = "NoIdFound";
                int id = -1;
                foreach (var property in properties)
                {
                    var customAttributes = property.GetCustomAttributes(typeof(IdColumn), false);
                    var isId = customAttributes.Count() > 0;
                    if (isId)
                    {
                        idColumn = property.Name;
                        id = (int)property.GetValue(entry);
                    }
                }

                if (id < 0)
                {
                    throw new ArgumentException("IdColumn not marked");
                }
                
                var bson = entry.ToBsonDocument();
                IMongoCollection<BsonDocument> collection =  GetDatabase().GetCollection<BsonDocument>(entry.GetType().FullName.Replace(".", ""));

                var result = collection.ReplaceOne(
                                filter: new BsonDocument(idColumn, id),
                                options: new UpdateOptions { IsUpsert = true },
                                replacement: bson);

                return result.IsAcknowledged && result.MatchedCount > 0;
            }
            catch (System.Exception ex) 
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        public BsonDocument CreateBsonFromObject(Object entry)
        {
            var document = new BsonDocument();
            var fields = entry.GetType().GetFields();
            var properties = entry.GetType().GetProperties();

            foreach (var item in fields)
            {
                if (item.GetType().IsArray) 
                {
                    var arrayDocument = new BsonArray();
                    foreach (var arrayItem in item.GetValue(entry) as IEnumerable)
                    {
                        arrayDocument.Add(arrayItem.ToString());
                    }

                    document.Add(item.Name, arrayDocument);
                }
                else
                {
                    document.Add(item.Name, item.GetValue(entry).ToString());
                }
            }

            foreach (var item in properties)
            {
                if (item.GetType().IsClass)
                {
                    document.Add(item.Name, CreateBsonFromObject(item.GetValue(entry)));
                }
                else if (item.GetType().IsArray) 
                {
                    var arrayDocument = new BsonArray();

                    foreach (var arrayItem in item.GetValue(entry) as IEnumerable)
                    {
                        if (arrayItem.GetType().IsClass)
                        {
                            arrayDocument.Add(CreateBsonFromObject(item.GetValue(entry)));
                        }
                        else
                        {
                            arrayDocument.Add(arrayItem.ToString());
                        }
                    }

                    document.Add(item.Name, arrayDocument);
                }
                else
                {
                    document.Add(item.Name, item.GetValue(entry).ToString());
                }
            }

            return document;
        }

        public IEnumerable Get(int parentId, Type type)
        {
            try
            {
                var properties = type.GetProperties();
                var idColumn = "NoIdFound";
                foreach (var property in properties)
                {
                    var isId = property.GetCustomAttributes(typeof(IdColumn), false).FirstOrDefault() != null;
                    if (isId)
                    {
                        idColumn = property.Name;
                        if (idColumn.Equals("id"))
                        {
                            idColumn = "_id";
                        }
                        break;
                    }
                }

                IMongoCollection<BsonDocument> collection =  GetDatabase().GetCollection<BsonDocument>(type.FullName.Replace(".", ""));

                var result = collection.Find(filter: new BsonDocument(idColumn, parentId));

                return result.ToEnumerable().Select(x => BsonSerializer.Deserialize(x, type));

            }
            catch (System.Exception ex) 
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            // no need to dispose anything here, but for other databases this might be needed
        }
    }
}