using SilverstoneWeatherApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SilverstoneWeatherApp.Controllers
{
    [SessionTimeout]
    public class SearchesController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ClearSearches()
        {
            TempData["alertMessage"] = "Search cleared";
            Session["SearchSession"] = null;
            return RedirectToAction("Index","WeatherAPI");
        }
    }
}