using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Core.Entities;
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
    public DbSet<User> Users {  get; set; }
    public DbSet<Appointment> Appointments { get; set; }

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.ApplyConfigurationsFromAssembly(typeof(BloodDonationSystemDbContext).Assembly);


        base.OnModelCreating(model);
    }
}
