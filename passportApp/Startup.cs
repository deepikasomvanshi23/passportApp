using Microsoft.Owin;
using Owin;
using passportApp;

[assembly: OwinStartup(typeof(Startup))]
namespace passportApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
