using BloodDonationSystem.Application.Entities;

namespace BloodDonationSystem.Core.Repositories;
public interface IAddressRepository
{
    public Task<Address?> Add(Address address);
    public Task<Address?> GetById(int id);
    public Task<Address?> Delete(int id);
    public Task<bool> Update(Address address);
}
