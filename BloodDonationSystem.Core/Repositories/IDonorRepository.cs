using BloodDonationSystem.Application.Entities;

namespace BloodDonationSystem.Core.Repositories;
public interface IDonorRepository
{
    public Task<Donor?> Add(Donor donor);
    public Task<Donor?> GetById(int id);
    public Task<bool> Update(Donor donor);
    public Task<bool> Delete(int id);
}
