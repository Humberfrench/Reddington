using System.Web.Helpers;
using Red.Application.AutoMapper;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Red.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.RegisterMappings();
            AntiForgeryConfig.SuppressIdentityHeuristicChecks = true;
        }

    }

    //public class MvcApplication : NinjectHttpApplication
    //{
    //    //protected  void Application_Start()
    //    //{
    //    //    AreaRegistration.RegisterAllAreas();
    //    //    FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
    //    //    RouteConfig.RegisterRoutes(RouteTable.Routes);
    //    //    BundleConfig.RegisterBundles(BundleTable.Bundles);
    //    //    AutoMapperConfig.RegisterMappings();
    //    //    //NinjectWebCommon.Start();
    //    //}

    //    protected override void OnApplicationStarted()
    //    {
    //        base.OnApplicationStarted();

    //        AreaRegistration.RegisterAllAreas();
    //        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
    //        RouteConfig.RegisterRoutes(RouteTable.Routes);
    //        BundleConfig.RegisterBundles(BundleTable.Bundles);
    //        AutoMapperConfig.RegisterMappings();

    //        var config = new HttpConfiguration();
    //        config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    //        config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
    //    }

    //    protected override IKernel CreateKernel()
    //    {
    //        var kernel = new StandardKernel();
    //        RegisterServices(kernel);
    //        return kernel;
    //    }

    //    /// <summary>
    //    /// Load your modules or register your services here!
    //    /// </summary>
    //    /// <param name="kernel">The kernel.</param>
    //    private static void RegisterServices(IKernel kernel)
    //    {


    //    }        

    //}
}
