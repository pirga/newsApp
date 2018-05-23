using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(newsApp.net.Startup))]
namespace newsApp.net
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
