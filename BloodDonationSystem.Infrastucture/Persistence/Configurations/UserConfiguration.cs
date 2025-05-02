using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodDonationSystem.Infrastucture.Persistence.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Password).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Role).IsRequired().HasMaxLength(100);

        builder.HasOne(d => d.Donor)
            .WithOne(u => u.User)
            .HasForeignKey<Donor>(d => d.UserId);

    }
}
