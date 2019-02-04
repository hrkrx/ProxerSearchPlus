using System;

namespace ProxerSearchPlus.model.v1
{
    public class Entry
    {
        public int id { get; set; }
        public string name { get; set; }
        public string genre { get; set; }
        public string medium { get; set; }
        public int count { get; set; }
        public int state { get; set; }
        public int rate_sum { get; set; }
        public int rate_count { get; set; }
        public string language { get; set; }
        public int? year { get; set; }
        public int? season { get; set; }
        public string type { get; set; }
        public DateTime updated = DateTime.UtcNow;
    }
}