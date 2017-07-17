using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KletterWetter.Startup))]
namespace KletterWetter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
