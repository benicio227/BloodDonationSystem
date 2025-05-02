using BloodDonationSystem.Core.Entities;
using BloodDonationSystem.Core.Repositories;
using BloodDonationSystem.Infrastucture.Persistence;

namespace BloodDonationSystem.Infrastucture.Repositories;
public class UserRepository : IUserRepository
{
    private readonly BloodDonationSystemDbContext _context;

    public UserRepository(BloodDonationSystemDbContext context)
    {
        _context = context;
    }
    public async Task<User> Add(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return user;
    }
}
