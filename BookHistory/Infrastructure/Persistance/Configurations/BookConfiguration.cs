using BookHistory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookHistory.Infrastructure.Persistance.Configurations
{
    public sealed class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(b => b.Title)
                .HasMaxLength(200);

            builder.Property(b => b.Description)
                .HasMaxLength(1000);
        }
    }
}
