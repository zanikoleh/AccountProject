using AccountProject.Core.Services;
using AccountProject.Core.Services.imp;
using DataAccess.Repositories;
using DataAccess.Repositories.impl;
using Microsoft.Practices.Unity;
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

            var container = new UnityContainer();
            container.RegisterType<IBankAccountService, BankAccountService>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserAccountService, UserAccountService>(new HierarchicalLifetimeManager());
            container.RegisterType<ITransactionService, TransactionService>(new HierarchicalLifetimeManager());
            container.RegisterType<IBankAccountRepository, BankAccountRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ITransactionRepository, TransactionRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserAccountRepository, UserAccountRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}
