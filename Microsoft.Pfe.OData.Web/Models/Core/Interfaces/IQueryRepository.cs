using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Pfe.OData.Web.Models.Core.Interfaces
{
    public interface IQueryRepository<T> 
        where T: class, IEntity
    {
        IQueryable<T> Get();
    }
}
