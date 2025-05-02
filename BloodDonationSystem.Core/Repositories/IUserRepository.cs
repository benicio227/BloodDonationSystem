using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Core.Entities;

namespace BloodDonationSystem.Core.Repositories;
public interface IUserRepository
{
    public Task<User> Add(User user);
}
