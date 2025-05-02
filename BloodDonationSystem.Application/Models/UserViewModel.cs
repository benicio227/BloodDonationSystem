using BloodDonationSystem.Application.Entities;

namespace BloodDonationSystem.Application.Models;
public class UserViewModel
{
    public UserViewModel(string fullName, DateTime birthDate, string gender, double weight, string bloodType, string rgFactor)
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
    public string Gender { get; set; }
    public double Weight { get; set; }
    public string BloodType { get; set; }
    public string RgFactor { get; set; }

    public static UserViewModel FromEntity(Donor donor)
    {
        return new UserViewModel(donor.FullName, donor.BirthDate, donor.Gender, donor.Weight, donor.BloodType, donor.RgFactor);
    }
}
