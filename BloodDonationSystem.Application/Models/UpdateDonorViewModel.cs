using BloodDonationSystem.Application.Entities;

namespace BloodDonationSystem.Application.Models;
public class UpdateDonorViewModel
{
    public UpdateDonorViewModel(string email, double weight, string bloodType, string rgFactor)
    {
        Email = email;
        Weight = weight;
        BloodType = bloodType;
        RgFactor = rgFactor;
    }

    public string Email { get; private set; }
    public double Weight { get; private set; }
    public string BloodType { get; private set; }
    public string RgFactor { get; private set; }

    public UpdateDonorViewModel FromEntity(Donor donor)
    {
        return new UpdateDonorViewModel(donor.Email, donor.Weight, donor.BloodType, donor.RgFactor);
    }
}
