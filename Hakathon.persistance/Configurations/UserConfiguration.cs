using Microsoft.EntityFrameworkCore;
using Hakathon.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hakathon.persistance.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(u => u.Username)
                .IsUnique();

            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Password)
                .IsRequired();

            builder.Property(u => u.DriverLicenseNumber)
                .IsRequired()
                .HasMaxLength(20);


            builder.HasMany(u => u.Cars)
                .WithOne(c => c.Owner)
                .HasForeignKey(c => c.UserId)  
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.HistoryRecords)
                .WithOne(h => h.User)
                .HasForeignKey(h => h.UserId);

            builder.HasMany(u => u.Cards)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);
        }
    }
}
