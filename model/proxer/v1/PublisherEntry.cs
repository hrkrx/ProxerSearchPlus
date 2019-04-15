using System;

namespace ProxerSearchPlus.model.proxer.v1
{
    [Serializable]
    public class PublisherEntry
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string country { get; set; }

        public override string ToString()
        {
            return string.Format("[id:{0}, name:{1}, type:{2} country:{3}]", id, name, type, country);
        }
    }
}