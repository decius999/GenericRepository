using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Microsoft.Pfe.OData.Web.Startup))]
namespace Microsoft.Pfe.OData.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
