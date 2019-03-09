using System;

namespace ProxerSearchPlus.model.v1
{
    public class TagEntry
    {
        public int id { get; set; }
        public int tid { get; set; }
        public DateTime timestamp { get; set; }
        public int rate_flag { get; set; }
        public int spoiler_flag { get; set; }
        public string tag { get; set; }
        public string description { get; set; }
    }
}