using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.ClientServices.Providers;
using System.Web.Script.Serialization;

namespace LetsBuyLocal.SDK.Services
{
    public class BaseService
    {
        private static string BaseURL;
        private static string ApiVersion;

        static BaseService()
        {
            BaseURL = "http://prerelease.api.letsbuylocal.com/";  //TODO: from config
            ApiVersion = "v1"; //TODO: from config
        }

        protected T Get<T>(string path)
        {
            string response = getClient().DownloadString(buildPath(path));
            var serializer = new JavaScriptSerializer();
            return serializer.Deserialize<T>(response);
        }

        private WebClient getClient()
        {
            var client = new WebClient();
            client.Headers.Add("Authorization", ConfigurationManager.AppSettings["AuthorizationToken"]);

            //if there is a store api key, send it
            if (ConfigurationManager.AppSettings["StoreApiKey"] != null)
            {
                client.Headers.Add("StoreApiKey", ConfigurationManager.AppSettings["StoreApiKey"]);
            }

            return client;
        }

        private string buildPath(string path)
        {
            return BaseURL + ApiVersion + "/" + path;
        }
    }
}
