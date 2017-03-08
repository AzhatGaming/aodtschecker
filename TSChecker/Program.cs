using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Net;

namespace TSChecker
{
    static class Program
    {
        public static Common.AOD.AODUserInformation userInfo;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            userInfo = new Common.AOD.AODUserInformation();

            if (!System.IO.Directory.Exists(string.Format(@"{0}AOD", System.IO.Path.GetTempPath())))
                System.IO.Directory.CreateDirectory(string.Format(@"{0}AOD", System.IO.Path.GetTempPath()));

            ///Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            //Application.Run(new MemEdit("aod_creelo", new Common.AOD.AODUserInformation()));

            //var a = DBCensus_Grabber.GetCharacterData(5428366106644078977).Result;
            //var x = Common.XmlTools.SerializeXmlObject<Common.Daybreak.CharacterList>(a);

            //var userInfo = new Common.AOD.AODUserInformation();

            //using (var fs = File.OpenRead(@"C:\Users\Tom\Documents\Visual Studio 2015\Projects\TSChecker\chars.csv"))
            //{
            //    using (var reader = new StreamReader(fs))
            //    {
            //        while (!reader.EndOfStream)
            //        {
            //            var line = reader.ReadLine();
            //            var vals = line.Split(',');

            //            bool valid = false;
            //            try
            //            {
            //                Convert.ToUInt64(vals[7]);
            //                valid = true;
            //            }
            //            catch
            //            {
            //                valid = false;
            //            }

            //            if (valid)
            //            {
            //                var mem = new Common.AOD.Member();
            //                if (userInfo.Members.Any(m => m.ForumName == WebUtility.HtmlEncode(vals[0])))
            //                {
            //                    mem = userInfo.Members.Where(m => m.ForumName == WebUtility.HtmlEncode(vals[0])).FirstOrDefault();
            //                    if (!mem.Characters.Any(c => c.CharacterId == Convert.ToUInt64(vals[7])))
            //                    {
            //                        var newChar = new Common.AOD.Character();
            //                        newChar.CharacterName = WebUtility.HtmlEncode(vals[12].Replace(" ", "&nbsp;"));
            //                        newChar.Faction = "AODR";
            //                        newChar.CharacterId = Convert.ToUInt64(vals[7]);
            //                        newChar.MemberSince = Convert.ToInt32(vals[8]);
            //                        newChar.MemberSinceDate = WebUtility.HtmlEncode(vals[9]);
            //                        newChar.Rank = WebUtility.HtmlEncode(vals[10]);
            //                        newChar.RankOrdinal = Convert.ToInt32(vals[11]);
            //                        mem.Characters.Add(newChar);
            //                    }
            //                }
            //                else
            //                {

            //                    mem.ForumName = WebUtility.HtmlEncode(vals[0]);
            //                    mem.Rank = WebUtility.HtmlEncode(vals[1]);
            //                    mem.Division = WebUtility.HtmlEncode(vals[2]);
            //                    mem.Status = WebUtility.HtmlEncode(vals[3]);

            //                    var newChar = new Common.AOD.Character();
            //                    newChar.CharacterName = WebUtility.HtmlEncode(vals[12].Replace(" ", "&nbsp;"));
            //                    newChar.Faction = "AODR";
            //                    newChar.CharacterId = Convert.ToUInt64(vals[7]);
            //                    newChar.MemberSince = Convert.ToInt32(vals[8]);
            //                    newChar.MemberSinceDate = WebUtility.HtmlEncode(vals[9]);
            //                    newChar.Rank = WebUtility.HtmlEncode(vals[10]);
            //                    newChar.RankOrdinal = Convert.ToInt32(vals[11]);

            //                    mem.Characters.Add(newChar);
            //                    userInfo.Members.Add(mem);
            //                }                       
            //            }
            //        }
            //    }
            //}

            //var serializer = new System.Xml.Serialization.XmlSerializer(typeof(Common.AOD.AODUserInformation));
            //var xml = "";
            //using (var sw = new StringWriter())
            //{
            //    using (XmlWriter writer = XmlWriter.Create(sw))
            //    {
            //        serializer.Serialize(writer, userInfo);
            //        xml = sw.ToString();
            //    }
            //}

            //XmlDocument doc = new XmlDocument();
            //XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            //XmlElement root = doc.DocumentElement;
            //doc.InsertBefore(xmlDeclaration, root);
            //doc.LoadXml(xml);

            //doc.Save(@"C:\Users\Tom\Documents\Visual Studio 2015\Projects\TSChecker\chars.xml");
            //doc.Save(string.Format(@"{0}\tmpaoduinfo.xml", System.IO.Path.GetTempPath()));
        }
    }
}
