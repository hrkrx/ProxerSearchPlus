using System;
using System.Collections.Generic;
using ProxerSearchPlus.model.proxer.v1;

namespace ProxerSearchPlus.controller.proxer.v1
{
    public static class EntryCache
    {
        private static Dictionary<int, Entry> _EntryCache = new Dictionary<int, Entry>();
        
        public static bool IsEntryUpToDate(int id, int updateAfterXHours = 12)
        {
            return _EntryCache.ContainsKey(id) ? _EntryCache[id].updated >= DateTime.UtcNow.AddHours(-updateAfterXHours): false;
        }

    }
}