using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Common.Daybreak
{
    [XmlRoot("outfit_list")]
    public class OutfitList
    {
        public OutfitList()
        {
            Outfit = new List<Outfit>();
        }

        //Elements
        [XmlElement("outfit")]
        public List<Outfit> Outfit { get; set; }
        //Attributes
        [XmlAttribute("limit")]
        public int Limit { get; set; }
        [XmlAttribute("returned")]
        public int Returned { get; set; }
        [XmlAttribute("milliseconds")]
        public int Milliseconds { get; set; }
        [XmlAttribute("seconds")]
        public float Seconds { get; set; }
    }

    [XmlRoot("outfit")]
    public class Outfit
    {
        public Outfit()
        {
            MembersList = new MembersList();
        }

        //Elements
        [XmlElement("members_list")]
        public MembersList MembersList { get; set; }
        //Attributes
        [XmlAttribute("outfit_id")]
        public ulong OutfitId { get; set; }
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("name_lower")]
        public string NameLower { get; set; }
        [XmlAttribute("alias")]
        public string Alias { get; set; }
        [XmlAttribute("alias_lower")]
        public string AliasLower { get; set; }
        [XmlAttribute("time_created")]
        public int TimeCreated { get; set; }
        [XmlAttribute("time_created_date")]
        public string TimeCreatedDate { get; set; }
        [XmlAttribute("leader_character_id")]
        public ulong LeaderCharacterId { get; set; }
        [XmlAttribute("member_count")]
        public int MemberCount { get; set; }
    }

    [XmlRoot("members_list")]
    public class MembersList
    {
        public MembersList()
        {
            Members = new List<Members>();
        }

        //Elements
        [XmlElement("members")]
        public List<Members> Members { get; set; }
    }

    [XmlRoot("members")]
    public class Members
    {
        public Members()
        {
            Name = new Name();
        }

        //Elements
        [XmlElement("name")]
        public Name Name { get; set; }
        //Attributes
        [XmlAttribute("character_id")]
        public ulong CharacterId { get; set; }
        [XmlAttribute("member_since")]
        public int MemberSince { get; set; }
        [XmlAttribute("member_since_date")]
        public string MemberSinceDate { get; set; }
        [XmlAttribute("rank")]
        public string Rank { get; set; }
        [XmlAttribute("rank_ordinal")]
        public int RankOrdinal { get; set; }
        [XmlAttribute("character_id_merged")]
        public ulong CharacterIdMerged { get; set; }
        [XmlAttribute("member_since_merged")]
        public int MemberSinceMerged { get; set; }
        [XmlAttribute("member_since_date_merged")]
        public string MemberSinceDateMerged { get; set; }
        [XmlAttribute("rank_merged")]
        public string RankMerged { get; set; }
        [XmlAttribute("rank_ordinal_merged")]
        public int RankOrdinalMerged { get; set; }
        [XmlAttribute("online_status")]
        public int OnlineStatus { get; set; }
    }

    [XmlRoot("name")]
    public class Name
    {
        [XmlAttribute("first")]
        public string First { get; set; }
        [XmlAttribute("first_lower")]
        public string FirstLower { get; set; }
    }

    // --- 
    // Character-specific objects
    // ---

    [XmlRoot("character_list")]
    public class CharacterList
    {
        public CharacterList()
        {
            Character = new List<Character>();
        }

        //Elements
        [XmlElement("character")]
        public List<Character> Character { get; set; }
        //Attributes
        [XmlAttribute("limit")]
        public int Limit { get; set; }
        [XmlAttribute("returned")]
        public int Returned { get; set; }
        [XmlAttribute("milliseconds")]
        public int Milliseconds { get; set; }
        [XmlAttribute("seconds")]
        public float Seconds { get; set; }
    }

    [XmlRoot("character")]
    public class Character
    {
        public Character()
        {
            Name = new Name();
            Times = new Times();
            Certs = new Certs();
            BattleRank = new BattleRank();
            DailyRibbon = new DailyRibbon();
            Outfit = new CharacterOutfit();
        }

        //Elements
        [XmlElement("name")]
        public Name Name { get; set; }
        [XmlElement("times")]
        public Times Times { get; set; }
        [XmlElement("certs")]
        public Certs Certs { get; set; }
        [XmlElement("battle_rank")]
        public BattleRank BattleRank { get; set; }
        [XmlElement("daily_ribbon")]
        public DailyRibbon DailyRibbon { get; set; }
        [XmlElement("outfit")]
        public CharacterOutfit Outfit { get; set; }
        //Attributes
        [XmlAttribute("character_id")]
        public ulong CharacterId { get; set; }
        [XmlAttribute("faction_id")]
        public int FactionId { get; set; }
        [XmlAttribute("head_id")]
        public int HeadId { get; set; }
        [XmlAttribute("title_id")]
        public int TitleId { get; set; }
        [XmlAttribute("profile_id")]
        public int ProfileId { get; set; }
    }

    [XmlRoot("outfit")]
    public class CharacterOutfit
    {
        //Attributes
        [XmlAttribute("outfit_id")]
        public ulong OutfitId { get; set; }
        [XmlAttribute("member_since_date")]
        public string MemberSinceData { get; set; }
        [XmlAttribute("outfit_id_merged")]
        public ulong OutfitIdMerged { get; set; }
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("name_lower")]
        public string NameLower { get; set; }
        [XmlAttribute("alias")]
        public string Alias { get; set; }
        [XmlAttribute("alias_lower")]
        public string AliasLower { get; set; }
        [XmlAttribute("time_created")]
        public int TimeCreated { get; set; }
        [XmlAttribute("time_created_date")]
        public string TimeCreatedDate { get; set; }
        [XmlAttribute("leader_character_id")]
        public ulong LeaderCharacterId { get; set; }
        [XmlAttribute("member_count")]
        public int MemberCount { get; set; }
    }

    [XmlRoot("times")]
    public class Times
    {
        //Attributes
        [XmlAttribute("creation")]
        public int Creation { get; set; }
        [XmlAttribute("creation_date")]
        public string CreationDate { get; set; }
        [XmlAttribute("last_save")]
        public int LastSave { get; set; }
        [XmlAttribute("last_save_date")]
        public string LastSaveDate { get; set; }
        [XmlAttribute("last_login")]
        public int LastLogin { get; set; }
        [XmlAttribute("last_login_date")]
        public string LastLoginDate { get; set; }
        [XmlAttribute("login_count")]
        public int LoginCount { get; set; }
        [XmlAttribute("minutes_played")]
        public int MinutesPlayed { get; set; }
    }

    [XmlRoot("certs")]
    public class Certs
    {
        //Attributes
        [XmlAttribute("earned_points")]
        public int EarnedPoints { get; set; }
        [XmlAttribute("gifted_points")]
        public int GiftedPoints { get; set; }
        [XmlAttribute("spent_points")]
        public int SpentPoints { get; set; }
        [XmlAttribute("available_points")]
        public int AvailablePoints { get; set; }
        [XmlAttribute("percent_to_next")]
        public double PercentToNext { get; set; }
    }

    [XmlRoot("battle_rank")]
    public class BattleRank
    {
        //Attributes
        [XmlAttribute("percent_to_next")]
        public int PercentToNext { get; set; }
        [XmlAttribute("value")]
        public int Value { get; set; }
    }

    [XmlRoot("daily_ribbon")]
    public class DailyRibbon
    {
        [XmlAttribute("count")]
        public int Count { get; set; }
        [XmlAttribute("time")]
        public int Time { get; set; }
        [XmlAttribute("date")]
        public string Date { get; set; }
    }
}
