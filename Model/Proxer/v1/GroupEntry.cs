using System;
using ProxerSearchPlus.Caching;

namespace ProxerSearchPlus.Model.Proxer.v1
{
    [Serializable]
    [Cacheable]
    public class GroupEntry
    {
        public int id { get; set; }
        public string name { get; set; }
        public string country { get; set; }

        public override string ToString()
        {
            return string.Format("[id:{0}, name:{1}, country:{2}]", id, name, country);
        }
    }
}