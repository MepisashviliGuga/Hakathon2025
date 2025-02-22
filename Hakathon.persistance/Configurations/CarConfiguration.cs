using Hakathon.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hakathon.persistance.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(c => c.Id);           
            builder.HasIndex(c=>c.CarIdentifier).IsUnique();
            builder.Property(c => c.CarIdentifier).IsRequired();
            builder.Property(c => c.Brand)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Serie)
                .IsRequired()
                .HasMaxLength(50);
            
            builder.HasOne(c => c.Owner)
                .WithMany(u => u.Cars) 
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
