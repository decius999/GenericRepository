using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.Pfe.OData.Web.Models.Core.Interfaces
{
    public interface IInMemoryRepositoryInitializer<T>
        where T: class, IEntity
    {
        List<T> GetData();
    }
}