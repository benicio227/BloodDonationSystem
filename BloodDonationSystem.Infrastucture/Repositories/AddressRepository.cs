using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Core.Repositories;
using BloodDonationSystem.Infrastucture.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationSystem.Infrastucture.Repositories;
public class AddressRepository : IAddressRepository
{
    private readonly BloodDonationSystemDbContext _context;

    public AddressRepository(BloodDonationSystemDbContext context)
    {
        _context = context;
    }
    public async Task<Address?> Add(Address address)
    {
        await _context.Addresses.AddAsync(address);
        await _context.SaveChangesAsync();

        return address;
    }
    public async Task<Address?> GetById(int id)
    {
        var address = await _context.Addresses.FirstOrDefaultAsync(a => a.DonorId == id);

        return address;
    }

    public async Task<Address?> Delete(int id)
    {
        var address = await _context.Addresses.FirstOrDefaultAsync(a => a.DonorId == id);

        _context.Addresses.Remove(address!);
        await _context.SaveChangesAsync();

        return address;
    }

}
