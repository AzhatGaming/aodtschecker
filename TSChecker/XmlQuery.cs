using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSChecker
{
    public static class XmlQuery
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async static Task<Tuple<List<string>, List<string>, List<string>, List<string>>> GetMembersWithStatus()
        {
            // AOD User Information (from xml)
            Program.userInfo = await GetAODUserInformation();

            // Outfit members
            var AODR = await GetOutfit(TSChecker.Properties.Settings.Default.AODRId);
            var AODC = await GetOutfit(TSChecker.Properties.Settings.Default.AODCId);
            var AODS = await GetOutfit(TSChecker.Properties.Settings.Default.AODSId);

            // Teamspeak members
            var teamspeakMembers = GetTeamspeakUsers();

            // Ingame members
            var ingameMembers = GetIngameMembers(AODR, AODC, AODS);
            // Ingame members compared to roster
            var ingameRoster = CompareIngameMembersWithRoster(ingameMembers);
            // Teamspeak members compared to roster
            var teamspeakRoster = CompareTeamspeakMembersWithRoster(ingameRoster.Item1, teamspeakMembers);
            // Merge members with errors
            var errorMembers = new List<string>();
            errorMembers.AddRange(ingameRoster.Item2);
            errorMembers.AddRange(teamspeakRoster.Item3);

            return new Tuple<List<string>, List<string>, List<string>, List<string>>(teamspeakRoster.Item1, teamspeakRoster.Item2, errorMembers, ingameRoster.Item3);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private async static Task<Common.AOD.AODUserInformation> GetAODUserInformation()
        {
            try
            {
                return await GoogleDriveTool.GetUserInformationFromDrive();
            }
            catch (Exception ex)
            {
                ReportError("Something went wrong with Google Drive.", ex);
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private async static Task<Common.Daybreak.Outfit> GetOutfit(string outfitId)
        {
            try
            {
                return (await DBCensus_Grabber.grabDataFromDaybreakCensus(outfitId)).Outfit.FirstOrDefault();
            }
            catch (Exception ex)
            {
                ReportError("Something went wrong with Daybreak.", ex);
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static List<string> GetTeamspeakUsers()
        {
            try
            {
                return TS3_Grabber.grabDataFromTeamspeak();
            }
            catch (Exception ex)
            {
                ReportError("Something went wrong with Teamspeak. (Are you logged in?)", ex);
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AODR"></param>
        /// <param name="AODC"></param>
        /// <param name="AODS"></param>
        /// <returns></returns>
        private static List<Tuple<string, ulong, ulong>> GetIngameMembers(Common.Daybreak.Outfit AODR, Common.Daybreak.Outfit AODC, Common.Daybreak.Outfit AODS)
        {
            var members = new List<Tuple<string, ulong, ulong>>();
            members.AddRange(GetOnlineFullMembers(AODR));
            members.AddRange(GetOnlineFullMembers(AODC));
            members.AddRange(GetOnlineFullMembers(AODS));
            return members;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="outfit"></param>
        /// <returns></returns>
        private static List<Tuple<string, ulong, ulong>> GetOnlineFullMembers(Common.Daybreak.Outfit outfit)
        {
            var members = new List<Tuple<string, ulong, ulong>>();
            var onlineMembers = FilterOnlineFullMembers(outfit);
            foreach (var member in onlineMembers)
            {
                members.Add(new Tuple<string, ulong, ulong>(member.Name.FirstLower, member.CharacterId, outfit.OutfitId));
            }
            return members;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ingameMembers"></param>
        private static Tuple<List<Common.AOD.Member>, List<string>, List<string>> CompareIngameMembersWithRoster(List<Tuple<string, ulong, ulong>> ingameMembers)
        {
            var roster = Program.userInfo.Members.Where(member => !string.IsNullOrEmpty(member.ForumName));
            var members_Entry = roster.Where(member => member.Characters.Any(character => ingameMembers.Any(ingame => ingame.Item2 == character.CharacterId)));
            var offlineMembers = from members in roster
                                 where !(members_Entry.Any(m => m.ForumName == members.ForumName))
                                 select members.ForumName;
            var members_NoEntry = from members in ingameMembers
                                  where !(members_Entry.Any(m => m.Characters.Any(c => c.CharacterId == members.Item2)))
                                  select members.Item1;
            return new Tuple<List<Common.AOD.Member>, List<string>, List<string>>(members_Entry.ToList(), members_NoEntry.ToList(), offlineMembers.ToList());
        }

        /// <summary>
        /// Compares the list of members that are ingame and in our roster, and a list of members who are on teamspeak.
        /// </summary>
        /// <param name="onlineIngameMembers">List of members that are ingame and have a roster entry.</param>
        /// <param name="teamspeakMembers">List of members that are in teamspeak.</param>
        /// <returns>Tuple with 3 lists - Item1 is online members, Item2 is offline members, Item3 is members with something incorrect on either teamspeak or roster.</returns>
        private static Tuple<List<string>, List<string>, List<string>> CompareTeamspeakMembersWithRoster(List<Common.AOD.Member> ingameMembers, List<string> teamspeakMembers)
        {
            var onlineMembers = new List<string>();
            var offlineMembers = new List<string>();
            var errorMembers = new List<string>();

            foreach (var member in ingameMembers)
            {
                bool match = false;
                foreach (var ts in teamspeakMembers)
                {
                    var splitName = SplitTeamspeakName(ts);
                    if (null != splitName)
                    {
                        if (splitName.Item1.Contains(member.ForumName.ToLower().Replace("aod_", "")))
                        {
                            if (splitName.Item2.ToLower() == Common.AOD.AODRank.GetAbbrvRank(member.Rank).ToLower())
                            {
                                onlineMembers.Add(member.ForumName);
                            }
                            else
                            {
                                errorMembers.Add(member.ForumName);
                            }
                            match = true;
                        }
                    }
                }
                if (!match)
                {
                    offlineMembers.Add(member.ForumName);
                }
            }
            return new Tuple<List<string>, List<string>, List<string>>(onlineMembers, offlineMembers, errorMembers);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="teamspeakName"></param>
        /// <returns></returns>
        private static Tuple<string, string> SplitTeamspeakName(string teamspeakName)
        {
            // Only check full members of TS
            if (teamspeakName.IndexOf("AOD_") >= 0)
            {
                var split = teamspeakName.Split('_');
                var rank = !string.IsNullOrEmpty(split.ElementAtOrDefault(1)) ? split.ElementAtOrDefault(1).ToLower() : "";
                var name = !string.IsNullOrEmpty(split.ElementAtOrDefault(2)) ? split.ElementAtOrDefault(2).ToLower() : "";
                return new Tuple<string, string>(name, rank);
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="outfit"></param>
        /// <returns></returns>
        private static IEnumerable<Common.Daybreak.Members> FilterOnlineFullMembers(Common.Daybreak.Outfit outfit)
        {
            return outfit.MembersList.Members.Where(member => member.RankOrdinal <= 4).Where(member => member.OnlineStatus != 0).Distinct();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errMsg"></param>
        /// <param name="ex"></param>
        private static void ReportError(string errMsg, Exception ex)
        {
            Common.CommonTools.LogMessage(string.Format("{0} -- Error: {1}\n{2}\n\n", DateTime.Now, errMsg, ex.ToString()));
        }
    }
}
