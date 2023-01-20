using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCPresentaion.Startup))]
namespace MVCPresentaion
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
