using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(POC.OAuth2.Startup))]
namespace POC.OAuth2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
