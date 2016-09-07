using Microsoft.Pfe.OData.Web.Models.BusinessServices;
using Microsoft.Pfe.OData.Web.Models.Core.Entities;
using Microsoft.Pfe.OData.Web.Models.Core.Interfaces;
using Microsoft.Pfe.OData.Web.Models.Data;
using Microsoft.Pfe.OData.Web.Models.Repositories;
using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;
using Unity.WebApi;
using System;
using Raven.Client.Document;

namespace Microsoft.Pfe.OData.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<DbContext, ApplicationContext>(new PerRequestLifetimeManager());
            container.RegisterType<ICustomerService, CustomerService>(new PerRequestLifetimeManager());
            container.RegisterType<IDataGenerator, DataGenerator>(new PerRequestLifetimeManager());

            container.RegisterType(typeof(IEfRepositoryInitializer<>), typeof(EfRepositoryInitializer<>), new PerRequestLifetimeManager());
            container.RegisterType(typeof(IInMemoryRepositoryInitializer<>), typeof(InMemoryRepositoryInitializer<>), new PerRequestLifetimeManager());

            //container.RegisterType(typeof(IQueryRepository<>), typeof(RavenDbQueryRepository<>), new PerRequestLifetimeManager());
            //container.RegisterType(typeof(IQueryRepository<>), typeof(EfQueryRepository<>), new PerRequestLifetimeManager());
            container.RegisterType(typeof(IQueryRepository<>), typeof(InMemoryQueryRepository<>), new ContainerControlledLifetimeManager());

            //CreateDefaultNoSqlData(container);

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        private static void CreateDefaultNoSqlData(IUnityContainer container)
        {
            var list = container.Resolve<IDataGenerator>().GetData(200);
            using (var ds = new DocumentStore { Url = "http://localhost:8080/" }.Initialize())
            {
                using (var session = ds.OpenSession("RavenDBCustomers"))
                {
                    foreach (var data in list)
                    {
                        session.Store(data);
                        Console.WriteLine(data.Id);
                    }
                    session.SaveChanges();
                }
            }
        }
    }
}