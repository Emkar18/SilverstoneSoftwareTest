using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace SilverstoneWeatherApp.Helper_classes
{
    public static class OpenWeatherAPI
    {
        private static readonly string appId = "9e061cb18c97d4b21e3e6107137b6307";

        public static string ApiRequest(string request)
        {
            string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&units=metric&cnt=1&APPID={1}", request, appId);

            using (WebClient client = new WebClient())
            {
                string response;
                try
                {
                    response = client.DownloadString(url);
                }
                catch (WebException)
                {
                    response = "City not found";
                }
                return response;
            }
        }

    }
}