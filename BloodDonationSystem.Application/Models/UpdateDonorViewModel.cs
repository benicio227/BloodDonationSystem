using BloodDonationSystem.Application.Entities;

namespace BloodDonationSystem.Application.Models;
public class UpdateDonorViewModel
{
    public UpdateDonorViewModel(double weight, string bloodType, string rgFactor)
    {
        Weight = weight;
        BloodType = bloodType;
        RgFactor = rgFactor;
    }
    public double Weight { get; private set; }
    public string BloodType { get; private set; }
    public string RgFactor { get; private set; }

    public UpdateDonorViewModel FromEntity(Donor donor)
    {
        return new UpdateDonorViewModel(donor.Weight, donor.BloodType, donor.RgFactor);
    }
}
