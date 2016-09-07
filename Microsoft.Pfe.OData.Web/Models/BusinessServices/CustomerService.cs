using Microsoft.Pfe.OData.Web.Models.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Pfe.OData.Web.Models.Core.Entities;

namespace Microsoft.Pfe.OData.Web.Models.BusinessServices
{
    public class CustomerService : ICustomerService
    {
        private readonly IQueryRepository<Customer> _customerRepo;
        public CustomerService(IQueryRepository<Customer> customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public IQueryable<Customer> GetCustomers()
        {
            return _customerRepo.Get();
        }
    }
}