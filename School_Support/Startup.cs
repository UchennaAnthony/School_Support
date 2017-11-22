using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(School_Support.Startup))]
namespace School_Support
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
