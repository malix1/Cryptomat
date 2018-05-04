using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2Net;
using B2Net.Models;
using B2Net.Http;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
namespace proje 
{
    class serverClient
    {
        B2Options options;
        B2FileList fileList;
        B2Client client;
        serverClient()
        {
            options = new B2Options()
            {
                AccountId = "5730116172ac",
                ApplicationKey = "0021f7da64163752b11645d6690755fbd8538bc345",
                BucketId = "f5279350818116d167320a1c",
                PersistBucket = true
            };
            client = new B2Client(B2Client.Authorize(options));
            fileList = client.Files.GetList(options.BucketId,100).Result;
        }
        void uploadFile()
        {
            B2UploadUrl upload = client.Files.GetUploadUrl(options.BucketId).Result;
        }

    }
}
