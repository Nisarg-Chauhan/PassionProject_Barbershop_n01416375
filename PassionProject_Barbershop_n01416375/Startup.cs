using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PassionProject_Barbershop_n01416375.Startup))]
namespace PassionProject_Barbershop_n01416375
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
