namespace ProxerSearchPlus.model.proxer.v1
{
    public class EntryDetail
    {
        public int id { get; set; }
        public string name { get; set; }
        public string genre { get; set; }
        public string fsk { get; set; }
        public string description { get; set; }
        public string medium { get; set; }
        public string adaption_type { get; set; }
        public string adaption_value { get; set; }
        public int count { get; set; }
        public int state { get; set; }
        public int rate_sum { get; set; }
        public int rate_count { get; set; }
        public int clicks { get; set; }
        public string kat { get; set; }
        public LizenzType license { get; set; }
        public bool gate { get; set; }
        public AdaptionEntry adaption_data { get; set; }
        public SynonymEntry[] names { get; set; }
        public string[] lang { get; set; }
        public SeasonEntry[] seasons { get; set; }
        public GroupEntry[] groups { get; set; }
        public PublisherEntry[] publisher { get; set; }
        public TagEntry[] tags { get; set; }
        public GenreEntry[] genres { get; set; }
        public CharacterEntry[] characters { get; set; }
        public PersonEntry[] persons { get; set; }
        public ForumEntry[] forum { get; set; }
    }

    public enum LizenzType 
    {
        Unbekannt = 0,
        NotLicensed = 1,
        Licensed = 2
    }
}