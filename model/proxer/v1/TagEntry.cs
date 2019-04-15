using System;
using ProxerSearchPlus.Caching;

namespace ProxerSearchPlus.model.proxer.v1
{
    [Cachable]
    public class TagEntry
    {
        public int id { get; set; }
        public int tid { get; set; }
        public DateTime timestamp { get; set; }
        public int rate_flag { get; set; }
        public int spoiler_flag { get; set; }
        public string tag { get; set; }
        public string description { get; set; }

        public override string ToString()
        {
            return string.Format("[id:{0}, tid:{1}, timestamp:{2}, rate_flag:{3}, spoiler_flag:{4}, tag:{5}, description:{6}]", id, tid, timestamp, rate_flag, spoiler_flag, tag, description);
        }
    }
}