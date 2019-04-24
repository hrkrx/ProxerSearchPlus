using System;
using ProxerSearchPlus.Api.Caching;

namespace ProxerSearchPlus.Api.Model.Proxer.v1
{

    [Cacheable]
    public class Entry
    {
        public int id { get; set; }
        public string name { get; set; }
        public string genre { get; set; }
        public string medium { get; set; }
        public string medium_format { get; set; }
        public int count { get; set; }
        public int state { get; set; }
        public int rate_sum { get; set; }
        public int rate_count { get; set; }
        public string language { get; set; }
        public int? year { get; set; }
        public int? season { get; set; }
        public string type { get; set; }
        public string kat { get; set; }
        public int? count_available { get; set; }

        public DateTime updated = DateTime.UtcNow;

        public override string ToString()
        {
            return string.Format("[id:{0}, name:{1}, genre:{2}, medium:{3}, medium_format:{4}, count:{5}, state:{6}, rate_sum:{7}, rate_count:{8}, language:{9}, year:{10}, season:{11}, type:{12}, kat:{13}, count_available:{14}]", 
                                id, name, genre, medium, medium_format, count, state, rate_sum, rate_count, language, year, season, type, kat, count_available);
        }
    }
}