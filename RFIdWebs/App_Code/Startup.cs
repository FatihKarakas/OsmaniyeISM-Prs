using Microsoft.Owin;
using Owin;
[assembly: OwinStartupAttribute(typeof(RFIdWebs.Startup))]
namespace RFIdWebs
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
