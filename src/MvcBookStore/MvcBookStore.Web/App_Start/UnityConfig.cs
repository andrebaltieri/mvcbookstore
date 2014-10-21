using Microsoft.Practices.Unity;
using MvcBookStore.Data.Repositories;
using MvcBookStore.Domain.Contracts;
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
            container.RegisterType<IAuthorRepository, AuthorRepository>(new HierarchicalLifetimeManager());
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}