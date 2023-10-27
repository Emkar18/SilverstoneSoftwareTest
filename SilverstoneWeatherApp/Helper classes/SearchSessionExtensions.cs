using SilverstoneWeatherApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SilverstoneWeatherApp.Helper_classes
{
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

        public static void SaveToSession(this HttpSessionStateBase session, Location location)
        {
            if (GetSearchSession(session) != null)
            {
                AddToSearchSession(session, location);
            }
            else
            {
                SearchSession search = new SearchSession();
                search.Locations.Add(location);
                SetSearchSession(session, search);
            }
        }
    }

}