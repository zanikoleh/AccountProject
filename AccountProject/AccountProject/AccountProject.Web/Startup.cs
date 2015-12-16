using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(AccountProject.Web.Startup))]
namespace AccountProject.Web
{
    public static class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            //HttpConfiguration config = new HttpConfiguration();
            //WebApiConfig.Register(config);
            //app.UseWebApi(config);
            app.MapSignalR();
        }
    }
}