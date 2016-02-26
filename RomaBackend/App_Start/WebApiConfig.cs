﻿using System.Net.Http.Headers;
using System.Web.Http;

namespace RomaBackend
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
			config.MapHttpAttributeRoutes();
			var json = config.Formatters.JsonFormatter;
			json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.All;
			json.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{action}/{id}",
				defaults: new { controller = "DataBase" ,id = RouteParameter.Optional }
			);
		}
	}
}