using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JCCCAppProj.Startup))]
namespace JCCCAppProj
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
