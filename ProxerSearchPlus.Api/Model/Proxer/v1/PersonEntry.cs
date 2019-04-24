using System;
using ProxerSearchPlus.Api.Caching;

namespace ProxerSearchPlus.Api.Model.Proxer.v1
{
    [Serializable]
    [Cacheable]
    public class PersonEntry
    {
        [IdColumn]
        public int pid { get; set; }
        public string name { get; set; }
        public string type { get; set; }

        public override string ToString()
        {
            return string.Format("[pid:{0}, name:{1}, type:{2}]", pid, name, type);
        }
    }
}