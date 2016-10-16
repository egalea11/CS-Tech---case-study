using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(caseStudy.Startup))]
namespace caseStudy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
