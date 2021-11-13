using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Connector.WebMVC.Startup))]
namespace Connector.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
