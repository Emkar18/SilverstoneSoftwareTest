using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace SilverstoneWeatherApp.Models
{
    public class SearchSession
    {
        public List<Location> Locations { get; set; }

        public SearchSession()
        {
            Locations = new List<Location>();
        }
    }
}
