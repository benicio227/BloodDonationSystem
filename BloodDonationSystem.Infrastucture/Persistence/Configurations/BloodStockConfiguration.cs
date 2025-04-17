using BloodDonationSystem.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodDonationSystem.Infrastucture.Persistence.Configurations;
public class BloodStockConfiguration : IEntityTypeConfiguration<BloodStock>
{
    public void Configure(EntityTypeBuilder<BloodStock> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.BloodType).IsRequired().HasMaxLength(3);
        builder.Property(b => b.RgFactor).IsRequired().HasMaxLength(3);
        builder.Property(b => b.AmountMl).IsRequired();
    }
}
