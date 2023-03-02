using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PerformanceStatistics.WebApplication
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{action}/{id}",
                defaults: new { controller = "Statistics", action = "Index", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultControllerApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { action = "Index", id = RouteParameter.Optional }
            );
        }
    }
}
