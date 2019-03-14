using System;

namespace ProxerSearchPlus.model.proxer.v1
{
    [Serializable]
    public class SynonymEntry
    {
        public int id { get; set; }
        public int eid { get; set; }
        public string type { get; set; }
        public string name { get; set; }
    }
}