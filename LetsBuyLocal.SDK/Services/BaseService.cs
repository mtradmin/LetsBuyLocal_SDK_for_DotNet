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
using LetsBuyLocal.SDK.Models;

namespace LetsBuyLocal.SDK.Services
{
    public class BaseService
    {
        private static string BaseURL;
        private static string ApiVersion;

        static BaseService()
        {
            BaseURL = ConfigurationManager.AppSettings["BaseUrl"];
            ApiVersion = ConfigurationManager.AppSettings["ApiVersion"];
        }

        protected T Get<T>(string path)
        {
            string response = getClient().DownloadString(buildPath(path));
            var serializer = new JavaScriptSerializer();
            return serializer.Deserialize<T>(response);
        }

        protected T Post<T>(string path, Object data)
        {
            var serializer = new JavaScriptSerializer();
            var dataString = serializer.Serialize(data);
            string response = getClient().UploadString(buildPath(path), "Post", dataString);
            return serializer.Deserialize<T>(response);
        }

        private WebClient getClient()
        {
            var client = new WebClient();
            client.Headers.Add("content-type", "application/Json");
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
