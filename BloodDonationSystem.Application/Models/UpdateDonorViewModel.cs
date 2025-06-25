using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Core.Enums;

namespace BloodDonationSystem.Application.Models;
public class UpdateDonorViewModel
{
    public UpdateDonorViewModel(double weight, BloodType bloodType, RgFactor rgFactor)
    {
        Weight = weight;
        BloodType = bloodType;
        RgFactor = rgFactor;
    }
    public double Weight { get; private set; }
    public BloodType BloodType { get; private set; }
    public RgFactor RgFactor { get; private set; }

    public UpdateDonorViewModel FromEntity(Donor donor)
    {
        return new UpdateDonorViewModel(donor.Weight, donor.BloodType, donor.RgFactor);
    }
}
