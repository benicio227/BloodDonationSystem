using BloodDonationSystem.Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationSystem.Infrastucture.Persistence;
public class BloodDonationSystemDbContext : DbContext
{
    public BloodDonationSystemDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Donor> Donors { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Donation> Donations { get; set; }
    public DbSet<BloodStock> bloodStocks { get; set; }

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<Donor>()
            .HasOne(d => d.Address)
            .WithOne(a => a.Donor)
            .HasForeignKey<Address>(a => a.Donor);

        model.Entity<Donor>()
            .HasMany(d => d.Donations)
            .WithOne(donation => donation.Donor)
            .HasForeignKey(donation => donation.DonorId);


        base.OnModelCreating(model);
    }
}
