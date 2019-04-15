using System;
using System.Collections.Generic;

namespace ProxerSearchPlus.Caching.Database
{
    public interface IDatabaseConnection
    {
        IEnumerable<object> NonGenericGet(Type type, int parentId);
        bool NonGenericPut(object entry, int parentId);
        bool Put<T>(T entry, int parentId);
        IEnumerable<T> Get<T>(int parentId);
    }
}