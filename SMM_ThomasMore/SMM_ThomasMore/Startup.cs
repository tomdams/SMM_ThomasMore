using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SMM_ThomasMore.Startup))]
namespace SMM_ThomasMore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
