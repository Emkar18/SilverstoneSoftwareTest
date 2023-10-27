using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using SilverstoneWeatherApp.Helper_classes;

namespace SilverstoneWeatherApp.Models
{
    public class Location
    {
        public string Name { get; set; }
        public OpenWeatherObject Weather { get; private set; }

        public void AddWeather(string weather)
        {
            Weather = CreateFromJSON(weather);
            Weather.Timestamp = DateTime.Now;
        }

        public OpenWeatherObject CreateFromJSON(string json)
        {
            OpenWeatherObject openWeather = (new JavaScriptSerializer()).Deserialize<OpenWeatherObject>(json);
            openWeather.Sys.Sunrise = UnitConverter.ConvertUnixTimestamp(openWeather.Sys.Sunrise, openWeather.Timezone);
            openWeather.Sys.Sunset = UnitConverter.ConvertUnixTimestamp(openWeather.Sys.Sunset, openWeather.Timezone);
            return openWeather;
        }
    }
}