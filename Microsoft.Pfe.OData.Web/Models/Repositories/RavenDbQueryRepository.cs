using Microsoft.Pfe.OData.Web.Models.Core.Interfaces;
using Raven.Client.Document;
using Raven.Client.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.Pfe.OData.Web.Models.Repositories
{
    public class RavenDbQueryRepository<T> : IQueryRepository<T>
        where T : class, IEntity
    {
        public IQueryable<T> Get()
        {
            var ds = new DocumentStore { Url = "http://localhost:8080/" }.Initialize();
            var session = ds.OpenSession("RavenDBCustomers");

            return session.Advanced.DocumentQuery<T>().AsQueryable();
            //return session.Query<T>();
        }
    }
}