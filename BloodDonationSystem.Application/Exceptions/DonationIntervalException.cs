namespace BloodDonationSystem.Api.ExceptionHandler;

public class DonationIntervalException : Exception
{
    public DonationIntervalException(string message) : base(message)
    {
        
    }
}
