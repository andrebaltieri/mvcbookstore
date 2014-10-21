using MvcBookStore.Data.Mappings;
using MvcBookStore.Domain;
using System.Data.Entity;

namespace MvcBookStore.Data.DataContexts
{
    public class MvcBookStoreDataContext : DbContext
    {
        public MvcBookStoreDataContext()
            : base("MvcBookStoreConnectionString")
        { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BookMap());
            modelBuilder.Configurations.Add(new AuthorMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
