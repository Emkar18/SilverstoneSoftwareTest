using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SilverstoneWeatherApp.Helper_classes
{
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