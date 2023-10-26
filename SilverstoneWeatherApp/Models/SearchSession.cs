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

    public static class SearchSessionExtensions
    {
        public static void SetSearchSession(this HttpSessionStateBase session, SearchSession searchSession)
        {
            session["SearchSession"] = searchSession;
        }

        public static void AddToSearchSession(this HttpSessionStateBase session, Location location)
        {
            SearchSession newSearchSession = GetSearchSession(session);
            newSearchSession.Locations.Add(location);
            SetSearchSession(session, newSearchSession);
        }

        public static SearchSession GetSearchSession(this HttpSessionStateBase session)
        {
            return (SearchSession)session["SearchSession"];
        }
    }

    public class SessionTimeoutAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            if (HttpContext.Current.Session["SearchSession"] == null)
            {
                filterContext.Result = new RedirectResult("~/WeatherAPI/EmptySession");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
