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

        if (address is null)
        {
            return null;
        }

        address.Delete();

        _context.Addresses.Update(address);
        await _context.SaveChangesAsync();

        return address;
    }

    public async Task<bool> Update(Address address)
    {
        _context.Addresses.Update(address);
        var updated = await _context.SaveChangesAsync();

        return updated > 0;
    }
}
