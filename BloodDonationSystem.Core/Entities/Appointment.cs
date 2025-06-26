using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Core.Enums;

namespace BloodDonationSystem.Core.Entities;
public class Appointment
{
    public Appointment(int donorId, DateTime scheduledAt, LocationType location)
    {
        DonorId = donorId;
        ScheduledAt = scheduledAt;
        Location = location;
        IsDeleted = false;
    }
    public int Id { get; private set; }
    public int DonorId { get; private set; }
    public DateTime ScheduledAt { get; private set; }
    public LocationType Location { get; private set; }
    public bool IsDeleted { get; private set; }
    public Donor? Donor { get; private set; }

    public void Delete()
    {
        IsDeleted = true;
    }

    public void Restore()
    {
        IsDeleted = false;
    }
}
