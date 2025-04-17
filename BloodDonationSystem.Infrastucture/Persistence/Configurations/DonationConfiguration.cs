using BloodDonationSystem.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodDonationSystem.Infrastucture.Persistence.Configurations;
public class DonationConfiguration : IEntityTypeConfiguration<Donation>
{
    public void Configure(EntityTypeBuilder<Donation> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.DonationDate).IsRequired();
        builder.Property(d => d.AmountMl).IsRequired();
    }
}
