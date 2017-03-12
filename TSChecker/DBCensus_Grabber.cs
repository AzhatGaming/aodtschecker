using System;
using System.Threading.Tasks;
using System.Net;
using Common.Daybreak;

namespace TSChecker
{
    static class DBCensus_Grabber
    {
        public static async Task<OutfitList> grabDataFromDaybreakCensus(string outfitId)
        {
            var censusObject = new OutfitList();

            const string requestItem = "outfit";
            const string queryObjs = "member,member_online_status,member_character(name)";

            var urlString = string.Format("https://{0}/{1}/get/{2}/{3}/{4}/?c:resolve={5}", 
                    Properties.Settings.Default.DaybreakURL, 
                    Properties.Settings.Default.DaybreakResponseFormat, 
                    Properties.Settings.Default.DaybreakPlanetsideQuery, 
                    requestItem, 
                    outfitId, 
                    queryObjs);

            string xmlResponse;
            using (var client = new WebClient())
            {
                xmlResponse = await client.DownloadStringTaskAsync(urlString);
                censusObject = Common.XmlTools.DeserializeXMLFromString<OutfitList>(xmlResponse);
            }

            return censusObject;
        }

        public static async Task<CharacterList> GetCharacterData(ulong characterId)
        {
            var censusObject = new CharacterList();

            const string requestItem = "character";
            const string queryObjs = "outfit";

            var urlString = string.Format("https://{0}/{1}/get/{2}/{3}/{4}/?c:resolve={5}",
                    Properties.Settings.Default.DaybreakURL,
                    Properties.Settings.Default.DaybreakResponseFormat,
                    Properties.Settings.Default.DaybreakPlanetsideQuery,
                    requestItem,
                    characterId.ToString(),
                    queryObjs);

            string xmlResponse;
            using (var client = new WebClient())
            {
                xmlResponse = await client.DownloadStringTaskAsync(urlString);
                censusObject = Common.XmlTools.DeserializeXMLFromString<CharacterList>(xmlResponse);
            }

            return censusObject;
        }
    }
}
