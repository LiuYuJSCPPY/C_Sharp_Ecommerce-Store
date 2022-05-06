using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EcommerceStore.Web.Startup))]
namespace EcommerceStore.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
