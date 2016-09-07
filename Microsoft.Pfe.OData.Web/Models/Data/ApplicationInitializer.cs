using Lohmann.RndContacts;
using Microsoft.Pfe.OData.Web.Models.Core.Entities;
using Microsoft.Pfe.OData.Web.Models.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Microsoft.Pfe.OData.Web.Models.Data
{
    public class ApplicationInitializer : CreateDatabaseIfNotExists<ApplicationContext>
    {
        private readonly IDataGenerator _dataGen;
        public ApplicationInitializer(IDataGenerator dataGen)
        {
            _dataGen = dataGen;
        }
        protected override void Seed(ApplicationContext context)
        {
            base.Seed(context);

            context.Customers.AddRange(_dataGen.GetData(50));

            context.SaveChanges();
        }
    }
}