using Microsoft.Pfe.OData.Web.Models.Core;
using Microsoft.Pfe.OData.Web.Models.Core.Entities;
using Microsoft.Pfe.OData.Web.Models.Core.Interfaces;
using Microsoft.Pfe.OData.Web.Models.Data;
using Microsoft.Pfe.OData.Web.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;

namespace Microsoft.Pfe.OData.Web.Controllers
{
    public class CustomersController : ODataController
    {
        private readonly ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;

        }

        [EnableQuery(
            EnableConstantParameterization = false,
            HandleNullPropagation = HandleNullPropagationOption.False)]
        public IHttpActionResult Get()
        {
            return Ok(_customerService.GetCustomers());
        }
    }
}