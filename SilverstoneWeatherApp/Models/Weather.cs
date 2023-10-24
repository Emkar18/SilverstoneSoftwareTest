using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SilverstoneWeatherApp.Models
{
    public class Weather
    {

        public Temperature TempInfo { get; set; }
        public DayLight DayLightInfo { get; set; }

    }

    public class Temperature
    {
        public string Temp { get; set; }
        public string Temp_min { get; set; }
        public string Temp_max { get; set; }

        public string Humidity { get; set; }
    }

    public class DayLight
    {
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
    }
}