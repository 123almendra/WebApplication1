using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppProyecto.Startup))]
namespace WebAppProyecto
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
