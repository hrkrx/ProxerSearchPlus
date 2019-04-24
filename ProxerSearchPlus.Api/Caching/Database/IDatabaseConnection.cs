using System;
using System.Collections;
using System.Collections.Generic;

namespace ProxerSearchPlus.Api.Caching.Database
{
    public interface IDatabaseConnection : IDisposable
    {
        bool Put(object entry);
        IEnumerable Get(int parentId, Type type);
    }
}