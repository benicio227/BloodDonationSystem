using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Core.Repositories;
using BloodDonationSystem.Infrastucture.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationSystem.Infrastucture.Repositories;
public class DonationRepository : IDonationRepository
{
    private readonly BloodDonationSystemDbContext _context;

    public DonationRepository(BloodDonationSystemDbContext context)
    {
        _context = context;
    }
    public async Task<Donation?> Add(Donation donation)
    {
        await _context.AddAsync(donation);
        await _context.SaveChangesAsync();

        return donation;
    }

    public async Task<Donation?> GetById(int id)
    {
        var donation = await _context.Donations.FirstOrDefaultAsync(d => d.DonorId == id);

        return donation;
    }
    public async Task Delete(int id)
    {
        var donation = await _context.Donations.FirstOrDefaultAsync(d => d.DonorId == id);

        _context.Donations.Remove(donation!);
        await _context.SaveChangesAsync();
    }

    public async Task<Donation?> GetLastDonationByDonorId(int id)
    {
        var donation = await _context.Donations.FirstOrDefaultAsync(d => d.DonorId == id);

        return donation;
    }
}
