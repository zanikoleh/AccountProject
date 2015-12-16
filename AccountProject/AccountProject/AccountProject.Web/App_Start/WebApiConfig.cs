using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using AccountProject.Core.Services;
using AccountProject.Models;
using AccountProject.Core.Services.imp;
using DataAccess.Repositories.impl;
using DataAccess.Repositories;

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
            container.RegisterType<IRepositoryBase, RepositoryBase>(new HierarchicalLifetimeManager());
            container.RegisterType<ITransactionRepository, TransactionRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserAccountRepository, UserAccountRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}
