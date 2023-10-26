using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SilverstoneWeatherApp.Models
{
    public abstract class Weather
    {
        public DateTime Timestamp { get; set; }
    }
}