using System;
using ProxerSearchPlus.Caching;

namespace ProxerSearchPlus.Model.Proxer.v1
{
    [Serializable]
    [Cacheable]
    public class GenreEntry
    {
        public int id { get; set; }
        public int tid { get; set; }
        public DateTime timestamp { get; set; }
        public string tag { get; set; }
        public string description { get; set; }

        public override string ToString()
        {
            return string.Format("[id:{0}, tid:{1}, timestamp:{2}, tag:{3}, description:{4}]", id, tid, timestamp, tag, description);
        }
    }
}