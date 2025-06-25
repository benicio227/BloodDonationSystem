using BloodDonationSystem.Core.Entities;
using BloodDonationSystem.Core.Enums;

namespace BloodDonationSystem.Application.Models;
public class AppointmentViewModel
{
    public AppointmentViewModel(DateTime scheduledAt, LocationType location)
    {
        ScheduledAt = scheduledAt;
        Location = location;
    }

    public DateTime ScheduledAt {  get; private set; }
    public LocationType Location { get; private set; }

    public static AppointmentViewModel FromEntity(Appointment appointment)
    {
        return new AppointmentViewModel(appointment.ScheduledAt, appointment.Location);
    }

}
