using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PresentationLayerMvc.Startup))]
namespace PresentationLayerMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
