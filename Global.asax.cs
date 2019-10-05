using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using GigHub.App_Start;

namespace GigHub
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
			Mapper.Initialize(c => c.AddProfile(new MappingProfile()));
	        GlobalConfiguration.Configure(WebApiConfig.Register);
			AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
