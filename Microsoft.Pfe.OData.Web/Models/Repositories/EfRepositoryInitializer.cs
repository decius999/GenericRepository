using Microsoft.Pfe.OData.Web.Models.Core;
using Microsoft.Pfe.OData.Web.Models.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Microsoft.Pfe.OData.Web.Models.Repositories
{
    public class EfRepositoryInitializer<T> : IEfRepositoryInitializer<T>
        where T : class, IEntity
    {
        private readonly DbContext context;

        public EfRepositoryInitializer(DbContext context)
        {
            this.context = context;
        }

        public DbSet<T> GetDbSet()
        {
            // Determine the DbSet<T> to initialize the repository with
            return (DbSet<T>)this.context.GetType().GetProperties()?.FirstOrDefault(p => p.PropertyType == typeof(DbSet<T>))?.GetValue(this.context, null);
        }
    }
}