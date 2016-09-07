using Microsoft.Pfe.OData.Web.Models.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.Pfe.OData.Web.Models.Repositories
{
    public class InMemoryQueryRepository<T> : IQueryRepository<T>
        where T : class, IEntity
    {
        private readonly List<T> _data;
        public InMemoryQueryRepository(IInMemoryRepositoryInitializer<T> initializer)
        {
            _data = initializer.GetData();
        }

        public IQueryable<T> Get()
        {
            return _data.AsQueryable();
        }
    }
}