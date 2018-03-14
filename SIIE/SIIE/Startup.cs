using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SIIE.Startup))]
namespace SIIE
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
