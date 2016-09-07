using Microsoft.Pfe.OData.Web.Models.Core.Entities;
using Microsoft.Pfe.OData.Web.Models.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.Pfe.OData.Web.Models.Repositories
{
    public class InMemoryRepositoryInitializer<T> : IInMemoryRepositoryInitializer<T>
        where T: class, IEntity
    {
        public List<Customer> Customers { get; set; }

        public InMemoryRepositoryInitializer(IDataGenerator dataGen)
        {
            Customers = new List<Customer>();
            Customers.AddRange(dataGen.GetData(10));
        }

        public List<T> GetData()
        {
            return this.GetType().GetProperties()?.FirstOrDefault(p => p.PropertyType == typeof(List<T>))?.GetValue(this, null) as List<T>;
        }
    }
}