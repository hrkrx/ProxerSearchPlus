using ProxerSearchPlus.util;
using ProxerSearchPlus.Caching;

namespace ProxerSearchPlus.Model.Proxer.v1
{
    [Cacheable]
    public class ForumEntry
    {
        public int id { get; set; }
        public int category_id { get; set; }
        public string category_name { get; set; }
        public string subject { get; set; }
        public int posts { get; set; }
        public int hits { get; set; }
        public long first_post_time { get; set; }
        public int first_post_userid { get; set; }
        public string first_post_guest_name { get; set; }
        public long last_post_time { get; set; }
        public int last_post_userid { get; set; }
        public string last_post_guest_name { get; set; }

        public override string ToString()
        {
            return StringUtils.ClassToString(this);
        }
    }
}