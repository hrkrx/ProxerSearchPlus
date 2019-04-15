using System;

namespace ProxerSearchPlus.model.proxer.v1
{
    [Serializable]
    public class AdaptionEntry
    {
        public int id { get; set; }
        public string name { get; set; }
        public string medium { get; set; }

        public override string ToString()
        {
            return string.Format("[id:{0}, name:{1}, medium:{2}]", id, name, medium);
        }
    }
}