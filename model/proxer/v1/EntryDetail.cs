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

        private LizenzType license1;

        public LizenzType Getlicense()
        {
            return license1;
        }

        public void Setlicense(LizenzType value)
        {
            license1 = value;
        }

        public bool gate { get; set; }

        private AdaptionEntry adaption_data1;

        public AdaptionEntry Getadaption_data()
        {
            return adaption_data1;
        }

        public void Setadaption_data(AdaptionEntry value)
        {
            adaption_data1 = value;
        }

        private SynonymEntry[] names1;

        public SynonymEntry[] Getnames()
        {
            return names1;
        }

        public void Setnames(SynonymEntry[] value)
        {
            names1 = value;
        }

        public string[] lang { get; set; }

        private SeasonEntry[] seasons1;

        public SeasonEntry[] Getseasons()
        {
            return seasons1;
        }

        public void Setseasons(SeasonEntry[] value)
        {
            seasons1 = value;
        }

        private GroupEntry[] groups1;

        public GroupEntry[] Getgroups()
        {
            return groups1;
        }

        public void Setgroups(GroupEntry[] value)
        {
            groups1 = value;
        }

        private PublisherEntry[] publisher1;

        public PublisherEntry[] Getpublisher()
        {
            return publisher1;
        }

        public void Setpublisher(PublisherEntry[] value)
        {
            publisher1 = value;
        }

        private TagEntry[] tags1;

        public TagEntry[] Gettags()
        {
            return tags1;
        }


        private GenreEntry[] genres1;

        public GenreEntry[] Getgenres()
        {
            return genres1;
        }

        public void Setgenres(GenreEntry[] value)
        {
            genres1 = value;
        }

        private CharacterEntry[] characters1;

        public CharacterEntry[] Getcharacters()
        {
            return characters1;
        }

        public void Setcharacters(CharacterEntry[] value)
        {
            characters1 = value;
        }

        private PersonEntry[] persons1;

        public PersonEntry[] Getpersons()
        {
            return persons1;
        }

        public void Setpersons(PersonEntry[] value)
        {
            persons1 = value;
        }

        private ForumEntry[] forum1;

        public ForumEntry[] Getforum()
        {
            return forum1;
        }

        public void Setforum(ForumEntry[] value)
        {
            forum1 = value;
        }
    }

    public enum LizenzType 
    {
        Unbekannt = 0,
        NotLicensed = 1,
        Licensed = 2
    }
}