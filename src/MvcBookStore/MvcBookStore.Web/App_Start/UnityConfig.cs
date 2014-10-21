using Microsoft.Practices.Unity;
using MvcBookStore.Data.Repositories;
using MvcBookStore.Domain.Contracts;
using MvcBookStore.Service;
using MvcBookStore.Service.Contracts;
using System.Web.Mvc;
using Unity.Mvc5;

namespace MvcBookStore.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IBookRepository, BookRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IBookService, BookService>(new HierarchicalLifetimeManager());            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}