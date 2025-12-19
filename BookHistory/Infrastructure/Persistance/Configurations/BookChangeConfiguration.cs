using BookHistory.Domain.Entities;
using BookHistory.Infrastructure.Persistance.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookHistory.Infrastructure.Persistance.Configurations
{
    public sealed class BookChangeConfiguration : IEntityTypeConfiguration<BookChange>
    {
        public void Configure(EntityTypeBuilder<BookChange> builder)
        {
            builder.Property(bc => bc.Description)
                .HasMaxLength(500);

            builder.Property(bc => bc.ChangeType)
                .HasConversion<string>();

            builder.HasIndex(bc => new { bc.BookId, bc.OccurredAt });
            builder.HasIndex(bc => bc.OccurredAt);

            builder.HasData(BookChangeSeed.All);
        }
    }
}
