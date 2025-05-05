using MediatR;

namespace BloodDonationSystem.Core.Events;
public class UserRegisteredDomainEvent : INotification
{
    public UserRegisteredDomainEvent(string email, string fullName)
    {
        Email = email;
        FullName = fullName;
    }

    public string Email {  get; set; }
    public string FullName { get; set; }
}
