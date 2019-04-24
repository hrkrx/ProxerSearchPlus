using System;
using ProxerSearchPlus.Api.Caching;

namespace ProxerSearchPlus.Api.Model.Proxer.v1
{
    [Serializable]
    [Cacheable]
    public class AdaptionEntry
    {
        [IdColumn]
        public int id { get; set; }
        public string name { get; set; }
        public string medium { get; set; }

        public override string ToString()
        {
            return string.Format("[id:{0}, name:{1}, medium:{2}]", id, name, medium);
        }
    }
}