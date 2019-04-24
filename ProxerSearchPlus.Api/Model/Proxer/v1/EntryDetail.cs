using System;
using System.Linq;
using ProxerSearchPlus.Api.Caching;

namespace ProxerSearchPlus.Api.Model.Proxer.v1
{
    public class EntryDetail
    {
        [IdColumn]
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

        public LizenzType license;

        public LizenzType Getlicense()
        {
            return license;
        }

        public void Setlicense(LizenzType value)
        {
            license = value;
        }

        public bool gate { get; set; }

        public AdaptionEntry adaption_data;

        public AdaptionEntry Getadaption_data()
        {
            return adaption_data;
        }

        public void Setadaption_data(AdaptionEntry value)
        {
            adaption_data = value;
        }

        public SynonymEntry[] names;

        public SynonymEntry[] Getnames()
        {
            return names;
        }

        public void Setnames(SynonymEntry[] value)
        {
            names = value;
        }

        public string[] lang { get; set; }

        public SeasonEntry[] seasons;

        public SeasonEntry[] Getseasons()
        {
            return seasons;
        }

        public void Setseasons(SeasonEntry[] value)
        {
            seasons = value;
        }

        public GroupEntry[] groups;

        public GroupEntry[] Getgroups()
        {
            return groups;
        }

        public void Setgroups(GroupEntry[] value)
        {
            groups = value;
        }

        public PublisherEntry[] publisher;

        public PublisherEntry[] Getpublisher()
        {
            return publisher;
        }

        public void Setpublisher(PublisherEntry[] value)
        {
            publisher = value;
        }

        public TagEntry[] tags;

        public TagEntry[] Gettags()
        {
            return tags;
        }

        public GenreEntry[] genres;

        public GenreEntry[] Getgenres()
        {
            return genres;
        }

        public void Setgenres(GenreEntry[] value)
        {
            genres = value;
        }

        public CharacterEntry[] characters;

        public CharacterEntry[] Getcharacters()
        {
            return characters;
        }

        public void Setcharacters(CharacterEntry[] value)
        {
            characters = value;
        }

        public PersonEntry[] persons;

        public PersonEntry[] Getpersons()
        {
            return persons;
        }

        public void Setpersons(PersonEntry[] value)
        {
            persons = value;
        }

        public ForumEntry[] forum;

        public ForumEntry[] Getforum()
        {
            return forum;
        }

        public void Setforum(ForumEntry[] value)
        {
            forum = value;
        }

        public override string ToString()
        {
            return string.Format("[id:{0}, name:{1}, genre:{2}, fsk:{3}, description:{4}, medium:{5}, adaption_type:{6}, adaption_value:{7} count:{5}, state:{6}, rate_sum:{7}, rate_count:{8}, clicks:{9}, kat:{10}, license:{11}, gate:{12}, adaption_data:{13}, names:[{14}], lang:[{15}], seasons:[{16}], groups:[{17}], publisher:[{18}], tags:[{19}], genres:[{20}], characters:[{21}], persons:[{22}], forum:[{23}]]", 
                                id, name, genre, fsk, description, medium, adaption_type, adaption_value, count, state, rate_sum, rate_count, clicks, kat, Getlicense(), gate, Getadaption_data()?.ToString(), Getnames() != null ? string.Join(", ", Getnames().Select(x => x.ToString())) : "", lang != null ? string.Join(", ", lang) : "", Getseasons() != null ? string.Join(", ", Getseasons().Select(x => x.ToString())) : "",
                                Getgroups() != null ? string.Join(", ", Getgroups().Select(x => x.ToString())) : "", Getpublisher() != null ? string.Join(", ", Getpublisher().Select(x => x.ToString())) : "", Gettags() != null ?  string.Join(", ", Gettags().Select(x => x.ToString())) : "", Getgenres() != null ? string.Join(", ", Getgenres().Select(x => x.ToString())) : "",
                                Getcharacters() != null ? string.Join(", ", Getcharacters().Select(x => x.ToString())) : "", Getpersons() != null ? string.Join(", ", Getpersons().Select(x => x.ToString())) : "", Getforum() != null ? string.Join(", ", Getforum().Select(x => x.ToString())) : "");
        }
    }

    public enum LizenzType 
    {
        Unbekannt = 0,
        NotLicensed = 1,
        Licensed = 2
    }
}