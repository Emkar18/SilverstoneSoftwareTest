using SilverstoneWeatherApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace SilverstoneWeatherApp.Helper_classes
{
    public class UnitConverter
    {
        public static string ConvertUnixTimestamp(string unixTimestamp, double timezone)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(Convert.ToDouble(unixTimestamp) + timezone);
            return dateTime.ToString("HH:mm");
        }
    }
}