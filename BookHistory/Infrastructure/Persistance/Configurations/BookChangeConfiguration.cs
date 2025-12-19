using BookHistory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookHistory.Infrastructure.Persistance.Configurations
{
    public sealed class BookChangeConfiguration : IEntityTypeConfiguration<BookChange>
    {
        public void Configure(EntityTypeBuilder<BookChange> builder)
        {
            builder.Property(x => x.Description)
                .HasMaxLength(500);

            builder.Property(x => x.ChangeType)
                .HasConversion<string>();
        }
    }
}
