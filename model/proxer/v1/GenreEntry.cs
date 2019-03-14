using System;

namespace ProxerSearchPlus.model.proxer.v1
{
    [Serializable]
    public class GenreEntry
    {
        public int id { get; set; }
        public int tid { get; set; }
        public DateTime timestamp { get; set; }
        public string tag { get; set; }
        public string description { get; set; }
    }
}