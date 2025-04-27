using BloodDonationSystem.Application.Entities;

namespace BloodDonationSystem.Core.Repositories;
public interface IDonationRepository
{
    public Task<Donation?> Add(Donation donation);
    public Task<Donation?> GetById(int id);
    public Task<List<Donation?>> GetAll(int id);
    public Task<Donation?> GetLastDonationByDonorId(int id);
    public Task<bool> Delete(int id);
}
