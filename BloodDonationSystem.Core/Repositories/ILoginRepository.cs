using BloodDonationSystem.Core.Entities;

namespace BloodDonationSystem.Core.Repositories;
public interface ILoginRepository
{
    public Task<User?> Login(string email, string password);
}
