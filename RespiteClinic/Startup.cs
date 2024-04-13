using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RespiteClinic.Startup))]
namespace RespiteClinic
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
