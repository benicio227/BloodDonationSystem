using BloodDonationSystem.Application.Entities;

namespace BloodDonationSystem.Core.Repositories;
public interface IDonorRepository
{
    public Task<Donor> Add(Donor donor);
}
