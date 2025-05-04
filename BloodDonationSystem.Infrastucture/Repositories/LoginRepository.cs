using BloodDonationSystem.Core.Entities;
using BloodDonationSystem.Core.Repositories;
using BloodDonationSystem.Infrastucture.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationSystem.Infrastucture.Repositories;
public class LoginRepository : ILoginRepository
{
    private readonly BloodDonationSystemDbContext _context;

    public LoginRepository(BloodDonationSystemDbContext context)
    {
        _context = context;
    }
    public async Task<User?> Login(string email, string password)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

        return user;
    }
}
