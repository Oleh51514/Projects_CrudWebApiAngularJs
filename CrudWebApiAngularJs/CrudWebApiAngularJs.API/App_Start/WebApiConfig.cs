using CrudWebApiAngularJs.API.Filters;
using CrudWebApiAngularJs.API.Response;
using CrudWebApiAngularJs.Bootstrap;
using FluentValidation.WebApi;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace CrudWebApiAngularJs.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {            
            // Web API configuration and services
            //config.Filters.Add(new AuthorizeAttribute());            
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Filters.Add(new ValidateModelStateFilter());
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // FluentValidation web api            
            FluentValidationModelValidatorProvider.Configure(config);
            
        }
    }
}
