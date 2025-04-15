using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Core.Repositories;
using BloodDonationSystem.Infrastucture.Persistence;

namespace BloodDonationSystem.Infrastucture.Repositories;
public class DonorRepository : IDonorRepository
{
    private readonly BloodDonationSystemDbContext _context;
    public DonorRepository(BloodDonationSystemDbContext context)
    {
        _context = context;
    }
    public async Task<Donor> Add(Donor donor)
    {
        await _context.AddAsync(donor);
        await _context.SaveChangesAsync();

        return donor;
    }
}
