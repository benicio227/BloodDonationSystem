using BloodDonationSystem.Application.Entities;

namespace BloodDonationSystem.Core.Repositories;
public interface IBloodStockRepository
{
    public Task<BloodStock> Add(BloodStock bloodStock);
    public Task<List<BloodStock>> GetAll();
    public Task Delete(int id);
}
