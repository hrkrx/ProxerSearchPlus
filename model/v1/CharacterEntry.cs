using System;

namespace ProxerSearchPlus.model.v1
{
    [Serializable]
    public class CharacterEntry
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
    }
}