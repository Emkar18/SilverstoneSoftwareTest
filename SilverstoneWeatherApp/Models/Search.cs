using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SilverstoneWeatherApp.Models
{
    public class Search
    {
        public int SearchID { get; set; }

        public int LocationID { get; set; }
        public int WeatherID { get; set; }

        public DateTime DateTime { get; set; }

        public virtual Location Location { get; set; }
        public virtual OpenWeatherObject Weather { get; set; }
    }
}