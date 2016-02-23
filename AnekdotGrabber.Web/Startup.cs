using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AnekdotGrabber.Web.Startup))]
namespace AnekdotGrabber.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
