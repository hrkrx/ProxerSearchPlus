using System;

namespace ProxerSearchPlus.model.v1
{
    [Serializable]
    public class SeasonEntry
    {
        public int id { get; set; }
        public string type { get; set; }
        public int year { get; set; }
        public int season { get; set; }
    }
}