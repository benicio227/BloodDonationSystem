using MediatR;

namespace BloodDonationSystem.Core.Events;
public class BloodStockBelowMinimumDomainEvent : INotification
{
    public string BloodType { get; }
    public string RgFactor { get; }
    public int AmountMl { get; }
    public int MinimumAmountMl { get; }

    public BloodStockBelowMinimumDomainEvent(string bloodType, string rgFactor, int amountMl, int minimumAmountMl)
    {
        BloodType = bloodType;
        RgFactor = rgFactor;
        AmountMl = amountMl;
        MinimumAmountMl = minimumAmountMl;
    }
}
