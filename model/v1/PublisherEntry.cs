using System;

namespace ProxerSearchPlus.model.v1
{
    [Serializable]
    public class PublisherEntry
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string country { get; set; }

    }
}