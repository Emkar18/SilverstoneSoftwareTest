using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Web.Script.Serialization;
using SilverstoneWeatherApp.Models;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace SilverstoneWeatherApp.Controllers
{
    public class WeatherAPIController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EmptySession()
        {
            TempData["AlertMessage"] = "No searches";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult WeatherInfo(Location location)
        {
            string response = ApiRequest(location.Name);
            if (response == "City not found")
            {
                TempData["alertMessage"] = "Invalid city";
                return RedirectToAction("Index");
            }
            else
            {
                location.Weather = ConvertJSON(response);
                location.Weather.Timestamp = DateTime.Now;

                string[] input = location.Name.Split(',');
                location.Name = input[0];
                SaveToSession(location);

                return View(location);
            }
        }

        private void SaveToSession(Location location)
        {
            if (SearchSessionExtensions.GetSearchSession(Session) != null)
            {
                SearchSessionExtensions.AddToSearchSession(Session, location);
            } else
            {
                SearchSession search = new SearchSession();
                search.Locations.Add(location);
                SearchSessionExtensions.SetSearchSession(Session, search);
            }
        }

        private string ApiRequest(string location)
        {
            string appId = "9e061cb18c97d4b21e3e6107137b6307";
            string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&units=metric&cnt=1&APPID={1}", location, appId);

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

        private OpenWeatherObject ConvertJSON(string response)
        {
            //Converting to OBJECT from JSON string.  
            OpenWeatherObject openWeather = (new JavaScriptSerializer()).Deserialize<OpenWeatherObject>(response);

            openWeather.Sys.Sunrise = ConvertUnixTimestamp(openWeather.Sys.Sunrise, openWeather.Timezone);
            openWeather.Sys.Sunset = ConvertUnixTimestamp(openWeather.Sys.Sunset, openWeather.Timezone);

            return openWeather;
        }

        private static string ConvertUnixTimestamp(string unixTimestamp, double timezone)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(Convert.ToDouble(unixTimestamp) + timezone);
            return dateTime.ToString("HH:mm");
        }
    }
}