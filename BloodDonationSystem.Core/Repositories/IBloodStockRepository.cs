using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Core.Enums;

namespace BloodDonationSystem.Core.Repositories;
public interface IBloodStockRepository
{
    public Task<BloodStock> Add(BloodStock bloodStock);
    public Task<List<BloodStock>> GetAll();

    public Task<BloodStock?> GetById(int id);

    public Task<BloodStock?> GetByTypeAndFactor(BloodType bloodType, RgFactor rhFactor);

    public Task Update(BloodStock bloodStock);
    public Task<bool> Delete(int id);
}
