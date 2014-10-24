using AutoMapper;
using MvcBookStore.Data.DataContexts;
using MvcBookStore.Domain;
using MvcBookStore.Web.Models.Book;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MvcBookStore.Web
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents(); 
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Mapper.CreateMap<Book, DisplayBookShortInfoViewModel>();
            Mapper.AssertConfigurationIsValid();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Items["_EntityContext"] = new MvcBookStoreDataContext();
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            var entityContext = HttpContext.Current.Items["_EntityContext"] as MvcBookStoreDataContext;
            if (entityContext != null)
                entityContext.Dispose();
        }
    }
}