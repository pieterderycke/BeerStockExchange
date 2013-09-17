using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BeerStockExchange.DataLayer;
using BeerStockExchange.Domain;
using BeerStockExchange.Util;
using Ninject;

namespace BeerStockExchange.Server
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            StandardKernel kernel = new StandardKernel();
            kernel.Bind<IBeerRepository>().To<EntityFrameworkBeerRepository>();

            config.DependencyResolver = new NinjectDependencyResolver(kernel);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
