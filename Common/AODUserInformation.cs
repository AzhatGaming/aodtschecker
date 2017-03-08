using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Common.AOD
{
    public sealed class AODRank
    {
        private readonly string Rank;
        private readonly string RankAbbreviation;

        public static readonly AODRank Recruit = new AODRank("Recruit", "Rct");
        public static readonly AODRank Cadet = new AODRank("Cadet", "Cdt");
        public static readonly AODRank Private = new AODRank("Private", "Pvt");
        public static readonly AODRank PrivateFirstClass = new AODRank("Private First Class", "Pfc");
        public static readonly AODRank Specialist = new AODRank("Specialist", "Spec");
        public static readonly AODRank Trainer = new AODRank("Trainer", "TR");
        public static readonly AODRank LanceCorporal = new AODRank("Lance Corporal", "LCpl");
        public static readonly AODRank Corporal = new AODRank("Corporal", "Cpl");
        public static readonly AODRank Sergeant = new AODRank("Sergeant", "Sgt");
        public static readonly AODRank StaffSergeant = new AODRank("Staff Sergeant", "SSgt");
        public static readonly AODRank MasterSergeant = new AODRank("Master Sergeant", "MSgt");
        public static readonly AODRank FirstSergeant = new AODRank("First Sergeant", "1stSgt");
        public static readonly AODRank CommandSergeant = new AODRank("Command Sergeant", "CmdSgt");
        public static readonly AODRank SergeantMajor = new AODRank("Sergeant Major", "SgtMaj");

        private AODRank(string Rank, string RankAbbreviation)
        {
            this.Rank = Rank;
            this.RankAbbreviation = RankAbbreviation;
        }

        public override string ToString()
        {
            return Rank;
        }

        public string ToAbbreviatedString()
        {
            return RankAbbreviation;
        }
    }

    [XmlRoot("members")]
    public class AODUserInformation
    {
        public AODUserInformation()
        {
            Members = new List<Member>();
        }

        public string ConvertToCSV()
        {
            string CSV = "Name,Rank,Game,Status,Join Date,Last Activity,GameName,character_id,member_since,member_since_date,rank,rank_ordinal,name\n";
            foreach (Member member in Members)
            {
                foreach (Character character in member.Characters)
                {
                    CSV += member.ForumName + ",";
                    CSV += member.Rank + ",";
                    CSV += member.Division + ",";
                    CSV += member.Status + ",";
                    CSV += member.JoinDate + ",";
                    CSV += member.LastActivity + ",";
                    CSV += character.CharacterName.ToLower() + ",";
                    CSV += character.CharacterId + ",";
                    CSV += character.MemberSince + ",";
                    CSV += character.MemberSinceDate + ",";
                    CSV += character.Rank + ",";
                    CSV += character.RankOrdinal + ",";
                    CSV += character.CharacterName + "\n";
                }
            }
            return CSV;
        }

        public AODUserInformation ParseCSV(string fileData)
        {
            var userInfo = new AODUserInformation();
            var lines = fileData.Split('\n');

            foreach (var line in lines)
            {
                var values = line.Split(',');

                bool valid = false;
                try
                {
                    Convert.ToUInt64(values[7]);
                    valid = true;
                }
                catch
                {
                    valid = false;
                }

                if (valid)
                {
                    var mem = new Common.AOD.Member();
                    if (userInfo.Members.Any(m => m.ForumName == WebUtility.HtmlEncode(values[0])))
                    {
                        mem = userInfo.Members.Where(m => m.ForumName == WebUtility.HtmlEncode(values[0])).FirstOrDefault();
                        if (!mem.Characters.Any(c => c.CharacterId == Convert.ToUInt64(values[7])))
                        {
                            var newChar = new Common.AOD.Character();
                            newChar.CharacterName = WebUtility.HtmlEncode(values[6].Replace(" ", "&nbsp;"));
                            newChar.Faction = "AODR";
                            newChar.CharacterId = Convert.ToUInt64(values[7]);
                            newChar.MemberSince = Convert.ToInt32(values[8]);
                            newChar.MemberSinceDate = WebUtility.HtmlEncode(values[9]);
                            newChar.Rank = WebUtility.HtmlEncode(values[10]);
                            newChar.RankOrdinal = Convert.ToInt32(values[11]);
                            mem.Characters.Add(newChar);
                        }
                    }
                    else
                    {

                        mem.ForumName = WebUtility.HtmlEncode(values[0]);
                        mem.Rank = WebUtility.HtmlEncode(values[1]);
                        mem.Division = WebUtility.HtmlEncode(values[2]);
                        mem.Status = WebUtility.HtmlEncode(values[3]);
                        mem.JoinDate = WebUtility.HtmlDecode(values[4]);
                        mem.LastActivity = WebUtility.HtmlDecode(values[5]);

                        var newChar = new Common.AOD.Character();
                        newChar.CharacterName = WebUtility.HtmlEncode(values[6].Replace(" ", "&nbsp;"));
                        newChar.Faction = "AODR";
                        newChar.CharacterId = Convert.ToUInt64(values[7]);
                        newChar.MemberSince = Convert.ToInt32(values[8]);
                        newChar.MemberSinceDate = WebUtility.HtmlEncode(values[9]);
                        newChar.Rank = WebUtility.HtmlEncode(values[10]);
                        newChar.RankOrdinal = Convert.ToInt32(values[11]);

                        mem.Characters.Add(newChar);
                        userInfo.Members.Add(mem);
                    }
                }
            }
            return userInfo;
        }

        [XmlElement("member")]
        public List<Member> Members { get; set; }
    }

    [XmlRoot("member")]
    public class Member
    {
        public Member()
        {
            Characters = new List<Character>();
            Flags = new List<Flags>();
        }

        [XmlElement("characters")]
        public List<Character> Characters { get; set; }
        [XmlElement("flags")]
        public List<Flags> Flags { get; set; }
        [XmlAttribute("name")]
        public string ForumName { get; set; }
        [XmlAttribute("rank")]
        public string Rank { get; set; }
        [XmlAttribute("division")]
        public string Division { get; set; }
        [XmlAttribute("status")]
        public string Status { get; set; }
        [XmlAttribute("joindate")]
        public string JoinDate { get; set; }
        [XmlAttribute("lastactivity")]
        public string LastActivity { get; set; }
    }

    [XmlRoot("character")]
    public class Character
    {
        [XmlAttribute("faction")]
        public string Faction { get; set; }
        [XmlAttribute("charactername")]
        public string CharacterName { get; set; }
        [XmlAttribute("character_id")]
        public UInt64 CharacterId { get; set; }
        [XmlAttribute("member_since")]
        public int MemberSince { get; set; }
        [XmlAttribute("member_since_date")]
        public string MemberSinceDate { get; set; }
        [XmlAttribute("rank")]
        public string Rank { get; set; }
        [XmlAttribute("rank_ordinal")]
        public int RankOrdinal { get; set; }
    }

    [XmlRoot("flags")]
    public class Flags
    {
        [XmlAttribute("date")]
        public DateTime Date { get; set; }
        [XmlAttribute("flaggedby")]
        public string FlaggedBy { get; set; }
        [XmlAttribute("note")]
        public string Note { get; set; }
    }
}
