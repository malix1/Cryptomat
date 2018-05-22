using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Dropbox;
using Dropbox.Api;
using System.IO;
using Dropbox.Api.Files;
namespace proje 
{
    class serverClient
    {
        FileStream fs;
        private const string apiKey = "qvml09a629f0n4d";
        private const string loopbackHost = "http://127.0.0.1:52475/";
        private readonly Uri redirectUri = new Uri(loopbackHost + "authorize");
        private readonly Uri JSRedirectUri = new Uri(loopbackHost+"token");
        public string accessToken = "CtkHQuOTCVAAAAAAAAAACKI7ZNCmgYPCGOJzN1lPAqwY2V0ymUwHCQnOUaI77xOt";
        DropboxClient Client = new DropboxClient("CtkHQuOTCVAAAAAAAAAACKI7ZNCmgYPCGOJzN1lPAqwY2V0ymUwHCQnOUaI77xOt");

        

        public async Task Upload(DropboxClient client,string folder, string fileName,string kasaIsmi)
        {
            string orjPath = folder.Replace('/', '\\');
            byte[] array = File.ReadAllBytes(@"c:"+orjPath+"\\"+fileName);
            folder = folder.Replace("sifreler",kasaIsmi);
            MemoryStream ms = new MemoryStream(array);
            var updated = await Client.Files.UploadAsync(folder + "/" + fileName, WriteMode.Overwrite.Instance, body: ms);
        }

       public async Task Download(DropboxClient client, string folder,string file,string kasaIsmi)
        {
            using (var response = await Client.Files.DownloadAsync(folder))
            {
                var files = await response.GetContentAsStreamAsync();
                using (FileStream Fs = File.Create(response.Response.Name))
                {
                    await files.CopyToAsync(Fs);
                }
            }
        }

        public void Delete(string path)
        {
            DeleteArg da = new DeleteArg(path);
        }
        
    }
}
