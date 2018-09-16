using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcIntroWebApp.Startup))]
namespace MvcIntroWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
