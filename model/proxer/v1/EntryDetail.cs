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

        private LizenzType license;

        public LizenzType Getlicense()
        {
            return license;
        }

        public void Setlicense(LizenzType value)
        {
            license = value;
        }

        public bool gate { get; set; }

        private AdaptionEntry adaption_data;

        public AdaptionEntry Getadaption_data()
        {
            return adaption_data;
        }

        public void Setadaption_data(AdaptionEntry value)
        {
            adaption_data = value;
        }

        private SynonymEntry[] names;

        public SynonymEntry[] Getnames()
        {
            return names;
        }

        public void Setnames(SynonymEntry[] value)
        {
            names = value;
        }

        public string[] lang { get; set; }

        private SeasonEntry[] seasons;

        public SeasonEntry[] Getseasons()
        {
            return seasons;
        }

        public void Setseasons(SeasonEntry[] value)
        {
            seasons = value;
        }

        private GroupEntry[] groups;

        public GroupEntry[] Getgroups()
        {
            return groups;
        }

        public void Setgroups(GroupEntry[] value)
        {
            groups = value;
        }

        private PublisherEntry[] publisher;

        public PublisherEntry[] Getpublisher()
        {
            return publisher;
        }

        public void Setpublisher(PublisherEntry[] value)
        {
            publisher = value;
        }

        private TagEntry[] tags;

        public TagEntry[] Gettags()
        {
            return tags;
        }


        private GenreEntry[] genres;

        public GenreEntry[] Getgenres()
        {
            return genres;
        }

        public void Setgenres(GenreEntry[] value)
        {
            genres = value;
        }

        private CharacterEntry[] characters;

        public CharacterEntry[] Getcharacters()
        {
            return characters;
        }

        public void Setcharacters(CharacterEntry[] value)
        {
            characters = value;
        }

        private PersonEntry[] persons;

        public PersonEntry[] Getpersons()
        {
            return persons;
        }

        public void Setpersons(PersonEntry[] value)
        {
            persons = value;
        }

        private ForumEntry[] forum;

        public ForumEntry[] Getforum()
        {
            return forum;
        }

        public void Setforum(ForumEntry[] value)
        {
            forum = value;
        }
    }

    public enum LizenzType 
    {
        Unbekannt = 0,
        NotLicensed = 1,
        Licensed = 2
    }
}