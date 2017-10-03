using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(POCDriverAppService.Startup))]

namespace POCDriverAppService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}