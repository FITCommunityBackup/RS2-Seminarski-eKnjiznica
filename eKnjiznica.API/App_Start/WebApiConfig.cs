using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using eKnjiznica.API.App_Start;
using eKnjiznica.Commons.ViewModels;
using eKnjiznica.CORE.Model.Admin;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace eKnjiznica.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
            config.Filters.Add(new AuthorizeAttribute());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<AdminAddVM, AdminAccount>();
            });
        }
    }
}
