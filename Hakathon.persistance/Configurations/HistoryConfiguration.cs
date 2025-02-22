using Hakathon.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hakathon.persistance.Configurations
{
    public class HistoryConfiguration : IEntityTypeConfiguration<History>
    {
        public void Configure(EntityTypeBuilder<History> builder)
        {
            builder.HasKey(h => h.Id);

            builder.Property(h => h.KilometersDriven)
                .IsRequired(false);

            builder.Property(h => h.AmountPaid)
                .HasPrecision(18, 2)
                .IsRequired(false);

            builder.Property(h => h.Date)
                .IsRequired();

            builder.Property(h => h.EndDate)
                .IsRequired(false);  

            builder.HasOne(h => h.User)
                .WithMany(u => u.HistoryRecords)
                .HasForeignKey(h => h.UserId)
                .OnDelete(DeleteBehavior.Restrict);  

            builder.HasOne(h => h.Car)
                .WithMany()
                .HasForeignKey(h => h.CarId)
                .OnDelete(DeleteBehavior.Restrict);  
            builder.HasOne(h => h.Card)
                .WithMany()
                .HasForeignKey(h => h.CardId)
                .OnDelete(DeleteBehavior.Restrict);  
        }

    }
}