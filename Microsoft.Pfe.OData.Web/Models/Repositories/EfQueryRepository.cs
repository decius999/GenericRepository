using Microsoft.Pfe.OData.Web.Models.Core;
using Microsoft.Pfe.OData.Web.Models.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Microsoft.Pfe.OData.Web.Models.Repositories
{
    public class EfQueryRepository<T> : IQueryRepository<T>
        where T: class, IEntity
    {
        private readonly DbSet<T> _dbSet;
        public EfQueryRepository(IEfRepositoryInitializer<T> initializer)
        {
            _dbSet = initializer.GetDbSet();
        }

        public IQueryable<T> Get()
        {
            return _dbSet.AsQueryable();
        }
    }
}