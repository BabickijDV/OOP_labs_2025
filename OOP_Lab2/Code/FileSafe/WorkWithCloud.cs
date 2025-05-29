using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Google;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;

namespace OOP_Lab2.FileSafe
{
    public class WorkWithCloud
    {

        private static DriveService GetService()
        {
            var tokenResponse = new TokenResponse
            {
                AccessToken = "",
                RefreshToken = "",
            };


            var applicationName = "Lab";// Use the name of the project in Google Cloud
            var username = "pavel1zd@gmail.com"; // Use your email


            var apiCodeFlow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = "",
                    ClientSecret = ""
                },
                Scopes = new[] { DriveService.Scope.Drive },
                DataStore = new FileDataStore(applicationName)
            });


            var credential = new UserCredential(apiCodeFlow, username, tokenResponse);



            var service = new DriveService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = applicationName
            });
            return service;
        }

        public string UploadFile(string fileName, int type, string folder, string fileDescription)
        {
            DriveService service = GetService();
            string fileMime="";
            var t = GetFiles(folder);
            foreach(var a in t)
            {
                if (a.Name == fileName) return "-1";
            }
            Stream file= new FileStream(fileName, FileMode.Open, FileAccess.Read); 
            
 
               
            //Stream file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            if (type == 0)
            {
                fileMime = "text/plain";
            }
            if (type == 1)
            {
                fileMime = "text/json";
            }
            if (type == 2)
            {
                fileMime = "text/md";
            }
            if (type == 3)
            {
                fileMime = "text/xml";
            }
            if (type == 4)
            {
                fileMime = "text/rtf";
            }
            var driveFile = new Google.Apis.Drive.v3.Data.File();
            driveFile.Name = fileName;
           // driveFile.Description = "111";
            driveFile.MimeType = fileMime;
            driveFile.Parents = new string[] { folder };
            //service.Files.Get
            //
           // service.Files.Update(driveFile, file, driveFile.MimeType,);
            var request = service.Files.Create(driveFile, file, driveFile.MimeType);
            request.Fields = "id";

            var response = request.Upload();
            if (response.Status != UploadStatus.Completed)
                throw response.Exception;
            file.Close();
            return request.ResponseBody.Id;
        }

        public IEnumerable<Google.Apis.Drive.v3.Data.File> GetFiles(string FolderId)
        {
            var service = GetService();
            
            var fileList = service.Files.List();
            fileList.Q = $"mimeType!='application/vnd.google-apps.folder' and '{FolderId}' in parents";
            fileList.Fields = "nextPageToken, files(id, name, size, mimeType)";

            var result = new List<Google.Apis.Drive.v3.Data.File>();
            string pageToken = null;
            do
            {
                fileList.PageToken = pageToken;
                var filesResult = fileList.Execute();
                var files = filesResult.Files;
                pageToken = filesResult.NextPageToken;
               
                result.AddRange(files);
            } while (pageToken != null);
        

        return result;
        }
        public string GetFileText(string FolderId,string fileId)
        {
            var service = GetService();
            var request = service.Files.Get(fileId);
            using (var stream = new MemoryStream())
            {
                request.Download(stream); // По умолчанию использует alt=media
                stream.Position = 0;

                // Для текстовых файлов:
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    string content = reader.ReadToEnd();
                    stream.Close();
                    reader.Close();
                    return content;
                }

                // Для бинарных файлов:
                // File.WriteAllBytes("output.png", stream.ToArray());
            }
            
        }
        public string UpdateFile(string fileName, int type, string folder, string fileDescription,string fileId)
        {
            var t = GetFiles(folder);
            foreach (var a in t)
            {
                if (a.Name == fileName) fileId = a.Id;
            }
            DriveService service = GetService();
            string fileMime = "";
            Stream file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            if (type == 0)
            {
                fileMime = "text/plain";
            }
            if (type == 1)
            {
                fileMime = "text/json";
            }
            if (type == 2)
            {
                fileMime = "text/md";
            }
            if (type == 3)
            {
                fileMime = "text/xml";
            }
            if (type == 4)
            {
                fileMime = "text/rtf";
            }
            var driveFile = new Google.Apis.Drive.v3.Data.File();
            //driveFile.Name = fileName;
            //driveFile.Description = "111";
            driveFile.MimeType = fileMime;
            var fileMetadata = service.Files.Get(fileId).Execute();
            driveFile.Name = fileMetadata.Name;
            //else driveFile.Name = Console.ReadLine()+".txt";
                //driveFile.addParents = new string[] { "1YjkitbfUoFkCHissqIBfZR9UTjfuqxQ8" };
                //

            var request = service.Files.Update(driveFile, fileId, file, driveFile.MimeType);
            request.Fields = "id, name, webViewLink";

            var response = request.Upload();
            if (response.Status != UploadStatus.Completed)
                throw response.Exception;
            file.Close();
            return driveFile.Name;
        }
        public void Delete(string fileId,string folder)
        {
            var service = GetService();
            var t = GetFiles(folder);
            foreach (var a in t)
            {
                if (a.Id == fileId)
                {
                    var command = service.Files.Delete(fileId);
                    var result = command.Execute();
                }
            }
            //var command = service.Files.Delete(fileId);
            //var result = command.Execute();
        }
    }
}
