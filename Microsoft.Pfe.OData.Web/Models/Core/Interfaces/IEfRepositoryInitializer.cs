using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Pfe.OData.Web.Models.Core.Interfaces
{
    public interface IEfRepositoryInitializer<T>
        where T : class, IEntity
    {
        DbSet<T> GetDbSet();
    }
}
