using BloodDonationSystem.Core.Entities;
using BloodDonationSystem.Core.Enums;

namespace BloodDonationSystem.Core.Repositories;
public interface IAppointmentRepository
{
    public Task<Appointment> Add(Appointment appointment);
    public Task<bool> ExistsConflict(DateTime scheduleAt, LocationType location);
}
