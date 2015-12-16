using AccountProject.Web.App_Start;
using System.Web.Http;

namespace AccountProject.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}