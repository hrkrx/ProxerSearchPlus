using System;

namespace ProxerSearchPlus.model.proxer.v1
{
    [Serializable]
    public class PersonEntry
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
    }
}