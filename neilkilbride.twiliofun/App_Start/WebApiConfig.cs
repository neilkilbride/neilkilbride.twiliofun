using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Owin.Security.OAuth;
using neilkilbride.twiliofun.Controllers;
using neilkilbride.twiliofun.formatters;
using Newtonsoft.Json.Serialization;

namespace neilkilbride.twiliofun
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Only want to use our custom XML formatter (no JSON etc.)
            config.Formatters.Clear();
            config.Formatters.Add(new EnhancedNamespaceXmlFormatter { UseXmlSerializer = true });

            // Web API routes
            config.MapHttpAttributeRoutes();
            
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
    
}
