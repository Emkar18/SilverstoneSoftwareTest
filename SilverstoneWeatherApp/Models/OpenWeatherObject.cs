using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace SilverstoneWeatherApp.Models
{
    public class OpenWeatherObject : Weather
    {
        public Main Main { get; set; }
        public Sys Sys { get; set; }
        public double Timezone { get; set; }
    }
    public class Main
    {
        public string Temp { get; set; }
        public string Temp_min { get; set; }
        public string Temp_max { get; set; }
        public string Humidity { get; set; }
    }
    public class Sys
    {
        public string Country { get; set; }
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
    }
}