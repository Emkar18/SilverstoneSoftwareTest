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
    public class SessionTimeoutAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["SearchSession"] == null)
            {
                filterContext.Result = new RedirectResult("~/WeatherAPI/EmptySession");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
