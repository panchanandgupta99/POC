using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace POC.WebApi.JWT
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.MessageHandlers.Add(new JWTValidationHandler());

            // List of delegating handlers.
            DelegatingHandler[] handlers = new DelegatingHandler[] {
    //new MessageHandler3()
};

            // Create a message handler chain with an end-point.
            var routeHandlers = HttpClientFactory.CreatePipeline(
                new HttpControllerDispatcher(config), handlers);


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
               name: "DefaultApi2",
               routeTemplate: "api2/{controller}/{id}",
               defaults: new { id = RouteParameter.Optional },
               constraints: null,
               handler: new JWTValidationHandler()
           );
        }
    }
}
