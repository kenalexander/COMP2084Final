using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(F2018Travel.Startup))]
namespace F2018Travel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
