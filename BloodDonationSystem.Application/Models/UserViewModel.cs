using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Core.Enums;

namespace BloodDonationSystem.Application.Models;
public class UserViewModel
{
    public UserViewModel(string fullName, DateTime birthDate, Gender gender, double weight, BloodType bloodType, RgFactor rgFactor)
    {
        FullName = fullName;
        BirthDate = birthDate;
        Gender = gender;
        Weight = weight;
        BloodType = bloodType;
        RgFactor = rgFactor;
    }
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public Gender Gender { get; set; }
    public double Weight { get; set; }
    public BloodType BloodType { get; set; }
    public RgFactor RgFactor { get; set; }

    public static UserViewModel FromEntity(Donor donor)
    {
        return new UserViewModel(donor.FullName, donor.BirthDate, donor.Gender, donor.Weight, donor.BloodType, donor.RgFactor);
    }
}
