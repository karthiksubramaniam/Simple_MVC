using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Employee_Details.Startup))]
namespace Employee_Details
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
