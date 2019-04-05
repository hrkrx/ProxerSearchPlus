using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProxerSearchPlus.model.proxer.v1;

namespace ProxerSearchPlus.controller.proxer.v1
{
    public static class CachingController
    {
        private static ApiClient _Client;
        private static bool _IsInitiated => _Client != null;

        private static Dictionary<Type, Dictionary<int, object>> _Cache = new Dictionary<Type, Dictionary<int, object>>();

        public static void Init(ApiClient client)
        {
            _Client = client;
        }

        public static T GetCachedEntry<T>(int id)
        {
            if (!_IsInitiated)
            {
                return default(T);
            }

            T result = default(T);
            if (!_Cache.ContainsKey(typeof(T)))
            {
                _Cache.Add(typeof(T), new Dictionary<int, object>());
            }

            if(_Cache[typeof(T)].ContainsKey(id))
            {
                result = (T)_Cache[typeof(T)][id];
            }

            return result;
        }

        public static void CacheEntry<T>(T entry, int id)
        {
            if (!_Cache.ContainsKey(typeof(T)))
            {
                _Cache.Add(typeof(T), new Dictionary<int, object>());
            }
            if(_Cache[typeof(T)].ContainsKey(id))
            {
                _Cache[typeof(T)][id] = entry;
            }
            else
            {
                _Cache[typeof(T)].Add(id, entry);
            }
        }
    }
}