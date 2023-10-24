using SilverstoneWeatherApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SilverstoneWeatherApp.Controllers
{
    public class LocationController : Controller
    {
        // GET: Location
        public ActionResult Location()
        {
            var location = new Location() { Name = "Test" };
            return View(location);
        }
    }
}