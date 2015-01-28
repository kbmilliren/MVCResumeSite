using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCResumeSite.Startup))]
namespace MVCResumeSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
