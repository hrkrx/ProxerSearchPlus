using System;
using ProxerSearchPlus.Caching;

namespace ProxerSearchPlus.Model.Proxer.v1
{
    [Serializable]
    [Cacheable]
    public class SeasonEntry
    {
        public int id { get; set; }
        public string type { get; set; }
        public int year { get; set; }
        public int season { get; set; }

        public override string ToString()
        {
            return string.Format("[id:{0}, type:{1}, year:{2}, season:{3}]", id, type, year, season);
        }
    }
}