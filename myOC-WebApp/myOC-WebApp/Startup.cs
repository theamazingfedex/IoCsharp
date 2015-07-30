using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(myOC_WebApp.Startup))]
namespace myOC_WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
