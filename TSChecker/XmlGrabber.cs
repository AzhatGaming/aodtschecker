using System;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Google.Apis;
using Common;
using Common.AOD;

namespace TSChecker
{
    public static class GoogleDriveTool
    {
        /// <summary>
        /// Gets the AOD User Information from storage on Google Drive.
        /// </summary>
        /// <returns>AODUserInformation object.</returns>
        public static async Task<AODUserInformation> GetUserInformationFromDrive()
        {
            var service = await GetService();
            var fileData = await DownloadFile(service, TSChecker.Properties.Settings.Default.DriveFileId);
            var userInfo = XmlTools.DeserializeXMLFromString<AODUserInformation>(Encoding.Unicode.GetString(fileData));
            CommonTools.SaveLocalFile(userInfo);
            return userInfo;
        }

        /// <summary>
        /// Updates the AOD User Information file on Google Drive
        /// </summary>
        /// <returns>true = success, false = failure.</returns>
        public static async Task<bool> SaveUserInformationToDrive()
        {
            var service = await GetService();
            return await UpdateFile(service, CommonTools.GetLocalFilePath(), TSChecker.Properties.Settings.Default.DriveFileId);
        }

        /// <summary>
        /// Gets the Google Drive service required to query, download, and update files on Google Drive.
        /// </summary>
        /// <returns>Returns the service.</returns>
        private static async Task<Google.Apis.Drive.v3.DriveService> GetService()
        {
            var scopes = new string[] { Google.Apis.Drive.v3.DriveService.Scope.Drive, Google.Apis.Drive.v3.DriveService.Scope.DriveFile };
            var clientId = TSChecker.Properties.Settings.Default.DriveClientId;
            var clientSecret = TSChecker.Properties.Settings.Default.DriveClientSecret;
            var credential = await Google.Apis.Auth.OAuth2.GoogleWebAuthorizationBroker.AuthorizeAsync(
                new Google.Apis.Auth.OAuth2.ClientSecrets { ClientId = clientId, ClientSecret = clientSecret },
                scopes,
                Environment.UserName,
                CancellationToken.None);

            return new Google.Apis.Drive.v3.DriveService(new Google.Apis.Services.BaseClientService.Initializer() { HttpClientInitializer = credential, ApplicationName = "TSChecker" });
        }

        /// <summary>
        /// Gets the Mime type of the specified file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static string GetMimeType(string fileName)
        {
            string mimeType = "application/unknown";
            string ext = System.IO.Path.GetExtension(fileName).ToLower();
            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (regKey != null && regKey.GetValue("Content Type") != null)
                mimeType = regKey.GetValue("Content Type").ToString();
            return mimeType;
        }

        /// <summary>
        /// Downloads the file from Google Drive.
        /// </summary>
        /// <param name="service"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        private static async Task<byte[]> DownloadFile(Google.Apis.Drive.v3.DriveService service, string fileId)
        {
            if (!string.IsNullOrEmpty(fileId))
            {
                try
                {
                    var request = service.Files.Get(fileId);
                    using (var memoryStream = new System.IO.MemoryStream())
                    {
                        await request.DownloadAsync(memoryStream);
                        return memoryStream.ToArray();
                    }
                }
                catch
                {
                    return null;
                }
            }
            return null;
        }

        /// <summary>
        /// Updates the file to Google Drive.
        /// </summary>
        /// <param name="service"></param>
        /// <param name="uploadFile"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        private static async Task<bool> UpdateFile(Google.Apis.Drive.v3.DriveService service, string uploadFile, string fileId)
        {
            if (System.IO.File.Exists(uploadFile))
            {
                var driveFile = new Google.Apis.Drive.v3.Data.File();
                driveFile.Name = System.IO.Path.GetFileName(uploadFile);
                driveFile.Description = "Updated from TSChecker App";
                driveFile.MimeType = GetMimeType(uploadFile);

                byte[] fileData = System.IO.File.ReadAllBytes(uploadFile);
                using (var memoryStream = new System.IO.MemoryStream(fileData))
                {
                    try
                    {
                        var request = service.Files.Update(driveFile, fileId, memoryStream, driveFile.MimeType);
                        await request.UploadAsync();
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
            return false;
        }
    }
}
