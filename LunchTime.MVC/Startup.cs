using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LunchTime.MVC.Startup))]
namespace LunchTime.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
