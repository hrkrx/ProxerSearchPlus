using System;

namespace ProxerSearchPlus.model.proxer.v1
{
    [Serializable]
    public class GroupEntry
    {
        public int id { get; set; }
        public string name { get; set; }
        public string country { get; set; }

    }
}