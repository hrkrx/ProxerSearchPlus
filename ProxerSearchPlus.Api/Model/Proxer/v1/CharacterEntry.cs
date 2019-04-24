using System;
using ProxerSearchPlus.Api.Caching;

namespace ProxerSearchPlus.Api.Model.Proxer.v1
{
    [Serializable]
    [Cacheable]
    public class CharacterEntry
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }

        public override string ToString()
        {
            return string.Format("[id:{0}, name:{1}, type:{2}]", id, name, type);
        }
    }
}