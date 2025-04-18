using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Core.Repositories;
using BloodDonationSystem.Infrastucture.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationSystem.Infrastucture.Repositories;
public class DonorRepository : IDonorRepository
{
    private readonly BloodDonationSystemDbContext _context;
    public DonorRepository(BloodDonationSystemDbContext context)
    {
        _context = context;
    }
    public async Task<Donor?> Add(Donor donor)
    {
        await _context.AddAsync(donor);
        await _context.SaveChangesAsync();

        return donor;
    }

    public async Task<Donor?> GetByEmail(string email)
    {
        var donor = await _context.Donors.FirstOrDefaultAsync(d => d.Email == email);

        return donor;
    }

    public async Task<Donor?> GetById(int id)
    {
        var donor = await _context.Donors.FirstOrDefaultAsync(d => d.Id == id);

        return donor;
    }
}
