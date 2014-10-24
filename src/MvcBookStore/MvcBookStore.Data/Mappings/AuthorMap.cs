using MvcBookStore.Domain;
using System.Data.Entity.ModelConfiguration;

namespace MvcBookStore.Data.Mappings
{
    public class AuthorMap : EntityTypeConfiguration<Author>
    {
        public AuthorMap()
        {
            ToTable("Author");

            HasKey(x => x.Id);
            Property(x => x.Bio).HasMaxLength(255);
            Property(x => x.Name).HasMaxLength(60);

            HasMany(x => x.Books).WithMany(x => x.Authors);
        }
    }
}
