using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SilverstoneWeatherApp.Controllers
{
    public class WeatherAPIController : Controller
    {
        // GET: WeatherAPI
        public ActionResult Index()
        {
            return View();
        }
    }
}