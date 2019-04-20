using System;
using System.Collections;
using System.Collections.Generic;

namespace ProxerSearchPlus.Caching.Database
{
    public interface IDatabaseConnection
    {
        bool Put(object entry);
        IEnumerable Get(int parentId, Type type);
    }
}