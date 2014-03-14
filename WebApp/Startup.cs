using Microsoft.Owin;
using Owin;

// Con OWIN configuramos la Clase que será inicializada automáticamente
[assembly: OwinStartupAttribute(typeof(WebApp.Startup))]
namespace WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
