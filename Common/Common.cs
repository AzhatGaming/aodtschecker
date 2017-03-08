using System;
using System.IO;

namespace Common
{
    public static class CommonTools
    {
        private const string localFileName = "tmpaoduinfo.xml";

        public static bool SaveLocalFile(AOD.AODUserInformation userInfoObject)
        {
            var xml = XmlTools.SerializeXmlObject<AOD.AODUserInformation>(userInfoObject);
            try
            {
                xml.Save(GetLocalFilePath());
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string GetLocalFilePath()
        {
            return string.Format(@"{0}{1}", Path.GetTempPath(), localFileName);
        }

        public static string GetRankAbbrv(string fullRank)
        {
            switch (fullRank)
            {
                case "cadet":
                    return "cdt";
                case "private":
                    return "pvt";
                case "private first class":
                    return "pfc";
                case "specialist":
                    return "spec";
                case "lance corporal":
                    return "lcpl";
                case "corporal":
                    return "cpl";
                case "sergeant":
                    return "sgt";
                case "staff sergeant":
                    return "ssgt";
                case "master sergeant":
                    return "msgt";
                case "first sergeant":
                    return "1sgt";
                default:
                    return "rct";
            }
        }

        public static void LogMessage(string msg)
        {
            using (var file = new System.IO.StreamWriter(string.Format(@"{0}AOD\log.txt", System.IO.Path.GetTempPath()), true))
            {
                file.WriteLine(msg);
            }
        }
    }
}
