using System;
using System.IO;
using Common.AOD;

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

        public static void LogMessage(string msg)
        {
            using (var file = new System.IO.StreamWriter(string.Format(@"{0}AOD\log.txt", System.IO.Path.GetTempPath()), true))
            {
                file.WriteLine(msg);
            }
        }
    }
}
