using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SilverstoneWeatherApp.Models
{
    public class Location
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public OpenWeatherObject Weather { get; set; }

        public virtual ICollection<Search> Searches { get; set; }

    }
}