using System;
using System.Collections.Generic;

namespace ProxerSearchPlus.Caching.Database.MongoDB
{
    public class MongoDBConnector : IDatabaseConnection
    {
        public IEnumerable<T> Get<T>(int parentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> NonGenericGet(Type type, int parentId)
        {
            throw new NotImplementedException();
        }

        public bool NonGenericPut(object entry, int parentId)
        {
            throw new NotImplementedException();
        }

        public bool Put<T>(T entry, int parentId)
        {
            throw new NotImplementedException();
        }
    }
}