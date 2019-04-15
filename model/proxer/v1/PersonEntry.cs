using System;

namespace ProxerSearchPlus.model.proxer.v1
{
    [Serializable]
    public class PersonEntry
    {
        public int pid { get; set; }
        public string name { get; set; }
        public string type { get; set; }

        public override string ToString()
        {
            return string.Format("[pid:{0}, name:{1}, type:{2}]", pid, name, type);
        }
    }
}