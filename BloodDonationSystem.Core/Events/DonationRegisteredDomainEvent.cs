using MediatR;

namespace BloodDonationSystem.Core.Events
{
    public class DonationRegisteredDomainEvent : INotification
    {
        public DonationRegisteredDomainEvent(string email, string fullName, int amountMl)
        {
            Email = email;
            FullName = fullName;
            AmountMl = amountMl;
        }
        public string Email {  get; set; }
        public string FullName {  get; set; }
        public int AmountMl {  get; set; }
    }
    
}
