using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProxerSearchPlus.Controller.Proxer.v1;

namespace ProxerSearchPlus.Caching
{
    public static class CachingController
    {
        private static Dictionary<Type, Dictionary<int, HashSet<object>>> _Cache = new Dictionary<Type, Dictionary<int, HashSet<object>>>();

        public static void CacheAllCacheableProperties(object parent, int parentId)
        {
            var fields = parent.GetType().GetFields();
            foreach (var field in fields)
            {
                var cacheable = field.FieldType.GetCustomAttributes(typeof(Cacheable), false).FirstOrDefault() != null; 
                var elementType = field.FieldType.GetElementType();
                if (elementType != null)
                {                    
                    cacheable = elementType.GetCustomAttributes(typeof(Cacheable), false).FirstOrDefault() != null;
                }

                if(cacheable)
                {
                    if (typeof(IEnumerable).IsAssignableFrom(field.FieldType))
                    {
                        IEnumerable value = field.GetValue(parent) as IEnumerable;
                        if (value != null)
                        {
                            foreach (var item in value)
                            {
                                NonGenericCachingEntry(item, parentId);
                            } 
                        }
                    }
                    else
                    {
                        NonGenericCachingEntry(field.GetValue(parent), parentId);
                    }
                }
            }
        }

        public static void PopulateEntryFromCache(object entry, int parentId)
        {
            var fields = entry.GetType().GetFields();
            foreach (var field in fields)
            {
                var cacheable = field.FieldType.GetCustomAttributes(typeof(Cacheable), false).FirstOrDefault() != null; 
                var elementType = field.FieldType.GetElementType();
                if (elementType != null)
                {                    
                    cacheable = elementType.GetCustomAttributes(typeof(Cacheable), false).FirstOrDefault() != null;
                }

                if(cacheable)
                {
                    if (typeof(IEnumerable).IsAssignableFrom(field.FieldType))
                    {
                        var entries = NonGenericGetCachedEntry(field.FieldType.GetElementType(), parentId);
                        if (entries?.Count > 0)
                        {
                            if (field.FieldType.IsArray)
                            {
                                field.SetValue(entry, Activator.CreateInstance(field.FieldType, new object[] { entries.Count })); // Add new []
                                dynamic arrayProperty = field.GetValue(entry);
                                var counter = 0;
                                foreach (dynamic item in entries)
                                {
                                    arrayProperty[counter] = item;
                                    counter++;
                                }

                            }
                            else
                            {
                                field.SetValue(entry, Activator.CreateInstance(field.FieldType)); // Add new List / whatever
                                dynamic listProperty = field.GetValue(entry);
                                foreach (dynamic item in entries)
                                {
                                    listProperty.Add(item);
                                }
                            }
                        }
                        
                    }
                    else
                    {
                        var entries = NonGenericGetCachedEntry(field.FieldType, parentId);
                        if (entries?.Count > 0)
                        {
                            field.SetValue(entry, entries.First());
                        }
                    }
                }
            }
        }

        private static HashSet<object> NonGenericGetCachedEntry(Type type, int parentId)
        {
            if(type.GetCustomAttributes(typeof(Cacheable), false).FirstOrDefault() == null)
            {
                throw new TypeNotCacheablesException("Type " + type.ToString() + " is not marked as Cacheable.");
            }

            HashSet<object> result = default(HashSet<object>);
            if (!_Cache.ContainsKey(type))
            {
                _Cache.Add(type, new Dictionary<int, HashSet<object>>());
            }

            if(_Cache[type].ContainsKey(parentId))
            {
                result = (HashSet<object>)_Cache[type][parentId];
            }

            return result;
        }

        public static HashSet<object> GetCachedEntry<T>(int parentId)
        {
            if(typeof(T).GetCustomAttributes(typeof(Cacheable), false).FirstOrDefault() == null)
            {
                throw new TypeNotCacheablesException("Type " + typeof(T).ToString() + " is not marked as Cacheable.");
            }

            HashSet<object> result = default(HashSet<object>);
            if (!_Cache.ContainsKey(typeof(T)))
            {
                _Cache.Add(typeof(T), new Dictionary<int, HashSet<object>>());
            }

            if(_Cache[typeof(T)].ContainsKey(parentId))
            {
                result = (HashSet<object>)_Cache[typeof(T)][parentId];
            }

            return result;
        }

        private static void NonGenericCachingEntry(object entry, int id)
        {
            Type type = entry.GetType();
            if(type.GetCustomAttributes(typeof(Cacheable), false).FirstOrDefault() == null)
            {
                throw new TypeNotCacheablesException("Type " + type.ToString() + " is not marked as Cacheable.");
            }

            if (!_Cache.ContainsKey(type))
            {
                _Cache.Add(type, new Dictionary<int, HashSet<object>>());
            }
            if(_Cache[type].ContainsKey(id))
            {
                _Cache[type][id].Add(entry);
            }
            else
            {
                _Cache[type].Add(id, new HashSet<object>());
                _Cache[type][id].Add(entry);
            }
        }

        public static void CacheEntry<T>(T entry, int id)
        {
            if(typeof(T).GetCustomAttributes(typeof(Cacheable), false).FirstOrDefault() == null)
            {
                throw new TypeNotCacheablesException("Type " + typeof(T).ToString() + " is not marked as Cacheable.");
            }

            if (!_Cache.ContainsKey(typeof(T)))
            {
                _Cache.Add(typeof(T), new Dictionary<int, HashSet<object>>());
            }
            if(_Cache[typeof(T)].ContainsKey(id))
            {
                _Cache[typeof(T)][id].Add(entry);
            }
            else
            {
                _Cache[typeof(T)].Add(id, new HashSet<object>());
                _Cache[typeof(T)][id].Add(entry);
            }
        }
    }
    
    [System.Serializable]
    public class TypeNotCacheablesException : System.Exception
    {
        public TypeNotCacheablesException() { }
        public TypeNotCacheablesException(string message) : base(message) { }
        public TypeNotCacheablesException(string message, System.Exception inner) : base(message, inner) { }
        protected TypeNotCacheablesException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}