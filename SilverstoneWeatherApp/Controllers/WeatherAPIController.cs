using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Web.Script.Serialization;
using SilverstoneWeatherApp.Models;

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
            return View(location);
        }
    }
}