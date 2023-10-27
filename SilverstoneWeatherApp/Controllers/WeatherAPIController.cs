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
using SilverstoneWeatherApp.Helper_classes;

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
            string response = OpenWeatherAPI.ApiRequest(location.Name);
            if (response == "City not found")
            {
                TempData["alertMessage"] = "Invalid city";
                return RedirectToAction("Index");
            }
            else
            {
                location.AddWeather(response);
                SearchSessionExtensions.SaveToSession(Session, location);
                return View(location);
            }
        }
    }
}