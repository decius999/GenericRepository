using Microsoft.Pfe.OData.Web.Models.Core.Entities;
using Microsoft.Pfe.OData.Web.Models.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Microsoft.Pfe.OData.Web.Models.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(IDataGenerator dataGen)
        {
            Database.SetInitializer(new ApplicationInitializer(dataGen));
        }

        public DbSet<Customer> Customers { get; set; }
    }
}