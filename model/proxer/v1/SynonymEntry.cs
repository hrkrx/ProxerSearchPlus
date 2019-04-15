using System;

namespace ProxerSearchPlus.model.proxer.v1
{
    [Serializable]
    public class SynonymEntry
    {
        public int id { get; set; }
        public int eid { get; set; }
        public string type { get; set; }
        public string name { get; set; }

        public override string ToString()
        {
            return string.Format("[id:{0}, eid:{1}, type:{2}, name:{3}]", id, eid, type, name);
        }
    }
}