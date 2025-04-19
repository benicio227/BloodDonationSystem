using BloodDonationSystem.Application.Entities;

namespace BloodDonationSystem.Core.Repositories;
public interface IBloodStockRepository
{
    public Task<BloodStock> Add(BloodStock bloodStock);
    public Task<List<BloodStock>> GetAll();

    public Task<BloodStock?> GetById(int id);

    public Task<BloodStock?> GetByTypeAndFactor(string bloodType, string rhFactor);

    public Task Update(BloodStock bloodStock);
    public Task<BloodStock?> Delete(int id);
}
