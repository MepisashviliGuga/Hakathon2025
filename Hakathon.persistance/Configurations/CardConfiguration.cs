using Hakathon.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hakathon.persistance.Configurations
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.CardNumber)
                .IsRequired()
                .HasMaxLength(16);

            builder.HasIndex(u => u.CardNumber)
                .IsUnique();

            builder.Property(c => c.Balance)
                .IsRequired()
                .HasPrecision(18, 2);                

            builder.HasOne(c => c.User)
                .WithMany(u => u.Cards)
                .HasForeignKey(c => c.UserId);
        }
    }
}
