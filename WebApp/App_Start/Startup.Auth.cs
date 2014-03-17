using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace WebApp
{
    public partial class Startup
    {
        // Para obtener más información para configurar la autenticación, visite http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Permitir que la aplicación use una cookie para almacenar información para el usuario que inicia sesión
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Quitar los comentarios de las siguientes líneas para habilitar el inicio de sesión con proveedores de inicio de sesión de terceros

            // Microsoft => https://account.live.com/developers/applications
            app.UseMicrosoftAccountAuthentication(
                clientId: "000000004C111F35",
                clientSecret: "deMeyaE3qw25PVxxH79ndrTfwyeVk9Ua");

            // Twitter => https://dev.twitter.com/
            app.UseTwitterAuthentication(
               consumerKey: "ZfAxJLtSy18Vc3ueOOA76w",
               consumerSecret: "EpEGdYKF2emLS6eouoPeiJe6tJi5C2pSOkBDnbUDKY");

            // Facebook => https://developers.facebook.com/apps/
            app.UseFacebookAuthentication(
               appId: "562262000476246",
               appSecret: "097b95d01c1f6942a3c08560c69a8848");

            app.UseGoogleAuthentication();
        }
    }
}