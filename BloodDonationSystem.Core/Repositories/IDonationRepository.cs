using BloodDonationSystem.Application.Entities;

namespace BloodDonationSystem.Core.Repositories;
public interface IDonationRepository
{
    public Task<Donation?> Add(Donation donation);
    public Task<Donation?> GetById(int id);
    public Task Delete(int id);
}
