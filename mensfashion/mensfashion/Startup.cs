using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mensfashion.Startup))]
namespace mensfashion
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
