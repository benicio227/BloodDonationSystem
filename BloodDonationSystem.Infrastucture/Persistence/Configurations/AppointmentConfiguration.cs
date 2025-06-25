using BloodDonationSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodDonationSystem.Infrastucture.Persistence.Configurations
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.ScheduledAt).IsRequired();
            builder.Property(a => a.Location).IsRequired();
            builder.Property(a => a.Location)
                .HasConversion<string>()
                .IsRequired();
            builder.HasOne(d => d.Donor)
                .WithOne(a => a.Appointment)
                .HasForeignKey<Appointment>(a => a.DonorId);
        }
    }
}
