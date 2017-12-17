using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Assignment_4_TestFileForMVC_2.Startup))]
namespace Assignment_4_TestFileForMVC_2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
