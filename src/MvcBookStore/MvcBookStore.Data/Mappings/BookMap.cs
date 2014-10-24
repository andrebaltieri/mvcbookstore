using MvcBookStore.Domain;
using System.Data.Entity.ModelConfiguration;

namespace MvcBookStore.Data.Mappings
{
    public class BookMap : EntityTypeConfiguration<Book>
    {
        public BookMap()
        {
            ToTable("Book");

            HasKey(x => x.Id);
            Property(x => x.ISBN).HasMaxLength(13);
            Property(x => x.QuantityOnHand);
            Property(x => x.QuantitySaled);
            Property(x => x.ReleaseDate);
            Property(x => x.Title).HasMaxLength(60);
            Property(x => x.Image).HasMaxLength(1024);

            HasMany(x => x.Authors).WithMany(x => x.Books)
                .Map(x =>
                {
                    x.ToTable("BookAuthor");
                    x.MapLeftKey("Book_Id");
                    x.MapRightKey("Author_Id");
                });
        }
    }
}
