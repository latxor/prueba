using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using Rhinog.Actividades.BaseDeDatos;
using Rhinog.BaseDeDatos;

namespace AppPruebasWeb
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {

            app.CreatePerOwinContext(rgContexto.Create);
            app.CreatePerOwinContext<Rhinog.BaseDeDatos.ApplicationUserManager>(Rhinog.BaseDeDatos.ApplicationUserManager.Create);
            app.CreatePerOwinContext<Rhinog.BaseDeDatos.ApplicationRoleManager>(Rhinog.BaseDeDatos.ApplicationRoleManager.Create);
            app.CreatePerOwinContext<Rhinog.BaseDeDatos.ApplicationSignInManager>(Rhinog.BaseDeDatos.ApplicationSignInManager.Create);

            //// Configure the db context, user manager and role manager to use a single instance per request
            //app.CreatePerOwinContext(() => { return new rgActividadesDbContext(); });

            ////pp.CreatePerOwinContext<Rhinog.BaseDeDatos.ApplicationUserManager>(Rhinog.BaseDeDatos.ApplicationUserManager.Create);
            //app.CreatePerOwinContext<Rhinog.BaseDeDatos.ApplicationUserManager>((opciones, contexto) => { return ApplicationUserManager.Create(opciones, new rgActividadesDbContext()); });

            //app.CreatePerOwinContext<Rhinog.BaseDeDatos.ApplicationRoleManager>(() => { return new ApplicationRoleManager(new ApplicationRoleStore(new rgActividadesDbContext())); });

            //app.CreatePerOwinContext<Rhinog.BaseDeDatos.ApplicationSignInManager>((var1,var2) => { return new ApplicationSignInManager(var2.GetUserManager<ApplicationUserManager>(), var2.Authentication); });

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<Rhinog.BaseDeDatos.ApplicationUserManager, ApplicationUser, string>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentityCallback: (manager, user) => user.GenerateUserIdentityAsync(manager),
                        // Need to add THIS line because we added the third type argument (int) above:
                            getUserIdCallback: (claim) => claim.GetUserId())
                }
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "",
            //   appSecret: "");

            //app.UseGoogleAuthentication(
            //    clientId: "",
            //    clientSecret: "");
        }
    }
}