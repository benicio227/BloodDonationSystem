using BloodDonationSystem.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodDonationSystem.Infrastucture.Persistence.Configurations;
public class DonorConfiguration : IEntityTypeConfiguration<Donor>
{
    public void Configure(EntityTypeBuilder<Donor> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.FullName).IsRequired().HasMaxLength(100);
        builder.Property(d => d.Email).IsRequired().HasMaxLength(100);
        builder.Property(d => d.BirthDate).IsRequired();
        builder.Property(d => d.Gender).IsRequired().HasMaxLength(20);
        builder.Property(d => d.Weight).IsRequired();
        builder.Property(d => d.BloodType).IsRequired().HasMaxLength(3);
        builder.Property(d => d.RgFactor).IsRequired().HasMaxLength(3);

        builder.HasOne(d => d.Address)
            .WithOne(a => a.Donor)
            .HasForeignKey<Address>(a => a.DonorId);

        builder.HasMany(d => d.Donations)
            .WithOne(doa => doa.Donor)
            .HasForeignKey(doa => doa.DonorId);
    }
}
