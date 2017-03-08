using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSChecker
{
    public static class TS3_Grabber
    {
        public static List<string> grabDataFromTeamspeak()
        {
            var userNames = new List<string>();
            var conn = new TelnetConnection("localhost", 25639);
            if (conn.IsConnected)
            {
                conn.WriteLine("clientlist");
                var userList = conn.Read();
                userNames = parseUserList(userList);
                conn = null;
            }
            return userNames;
        }

        private static List<string> parseUserList(string userList)
        {
            var userNames = new List<string>();
            var users = userList.Split('|');
            foreach (string user in users)
            {
                var fields = user.Split(' ');
                foreach (string field in fields)
                {
                    if (field.Contains("client_nickname="))
                    {
                        var fullUserName = field.Replace("client_nickname=", "");
                        userNames.Add(fullUserName);
                    }
                }
            }
            return userNames;
        }
    }
}
