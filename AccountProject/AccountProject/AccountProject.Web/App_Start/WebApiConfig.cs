using AccountProject.Core.Services;
using AccountProject.Core.Services.imp;
using AccountProject.Web.App_Start;
using DataAccess.Repositories;
using DataAccess.Repositories.impl;
using Microsoft.Practices.Unity;
using Newtonsoft.Json.Serialization;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace AccountProject.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            IoCRegistry.Resolve(config);
            FormaterRegistry.Resolve(config);
        }
    }
}