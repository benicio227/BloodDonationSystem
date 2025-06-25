using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Core.Enums;
using MediatR;

namespace BloodDonationSystem.Core.Events;
public class AppointmentRegisteredDomainEvent : INotification
{
    public AppointmentRegisteredDomainEvent(string fullName, string email, DateTime scheduledAt, LocationType location)
    {
        FullName = fullName;
        Email = email;
        ScheduledAt = scheduledAt;
        Location = location;
    }
    public string FullName {  get; set; }
    public string Email { get; set; }   
    public DateTime ScheduledAt { get; set; }
    public LocationType Location { get; set; }

}
