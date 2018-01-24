using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmployeeAuthentication.Startup))]
namespace EmployeeAuthentication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
