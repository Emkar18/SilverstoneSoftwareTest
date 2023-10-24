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

namespace SilverstoneWeatherApp.Controllers
{
    public class WeatherAPIController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WeatherInfo(Location location)
        {
            string appId = "9e061cb18c97d4b21e3e6107137b6307";
            string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&units=metric&cnt=1&APPID={1}", location.Name, appId);

            using (WebClient client = new WebClient())
            {
                string Response = client.DownloadString(url);

                JObject Json = JObject.Parse(Response);
                JToken TempInfo = Json["main"];
                JToken SunInfo = Json["sys"];

                Temperature Temperature = TempInfo.ToObject<Temperature>();
                DayLight DayLight = SunInfo.ToObject<DayLight>();

                Weather Weather = new Weather
                {
                    TempInfo = Temperature,
                    DayLightInfo = DayLight 
                };

                location.Weather = Weather;
            }

            return View(location);
        }
    }
}