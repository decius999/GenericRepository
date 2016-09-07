using Lohmann.RndContacts;
using Microsoft.Pfe.OData.Web.Models.Core.Entities;
using Microsoft.Pfe.OData.Web.Models.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.Pfe.OData.Web.Models.Data
{
    public class DataGenerator : IDataGenerator
    {
        public List<Customer> GetData(int count)
        {
            var random = new Random();
            var data = new List<Customer>();
            var contacts = RandomContactGenerator.Default.GenerateRandomContacts(count);

            foreach (var contact in contacts)
            {
                data.Add(new Customer
                {
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    Age = random.Next(0, 150)
                });
            }

            return data;
        }
    }
}