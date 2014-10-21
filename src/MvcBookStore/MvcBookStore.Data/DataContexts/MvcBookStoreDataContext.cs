using MvcBookStore.Domain;
using System.Data.Entity;

namespace MvcBookStore.Data.DataContexts
{
    public class MvcBookStoreDataContext : DbContext
    {
        public MvcBookStoreDataContext()
            : base("MvcBookStoreConnectionString")
        {
            Database.SetInitializer<MvcBookStoreDataContext>(new MvcBookStoreDataContextInitializer());
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }

    public class MvcBookStoreDataContextInitializer : DropCreateDatabaseIfModelChanges<MvcBookStoreDataContext>
    {
        protected override void Seed(MvcBookStoreDataContext context)
        {
            var book = new Book("Os filhos de Hurin", "12345678910");
            var author = new Author("J.R.R Tolkien", "Escritor muito bom");
            book.AddAuthor(author);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
