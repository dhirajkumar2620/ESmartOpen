using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ESmartDr.Startup))]
namespace ESmartDr
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
