using AccountProject.Core.Services;
using AccountProject.Core.Services.imp;
using DataAccess.Repositories;
using DataAccess.Repositories.impl;
using Microsoft.Practices.Unity;
using System.Web.Http;

namespace AccountProject.Web.App_Start
{
    public static class IoCRegistry
    {
        private static UnityContainer container = new UnityContainer();
        public static void Resolve(HttpConfiguration config)
        {
            IoCRegistry.Registry();
            config.DependencyResolver = new UnityResolver(container);
        }

        public static void Registry()
        {
            container = new UnityContainer();

            container.RegisterType<IBankAccountService, BankAccountService>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserAccountService, UserAccountService>(new HierarchicalLifetimeManager());
            container.RegisterType<ITransactionService, TransactionService>(new HierarchicalLifetimeManager());
            container.RegisterType<IBankAccountRepository, BankAccountRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ITransactionRepository, TransactionRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserAccountRepository, UserAccountRepository>(new HierarchicalLifetimeManager());
        }
    }
}