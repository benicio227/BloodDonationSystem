using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Core.Enums;

namespace BloodDonationSystem.Application.Models;
public class DonorViewModel
{
    public DonorViewModel(int id, string fullName, DateTime birthDate, Gender gender, double weight, BloodType bloodType, RgFactor rgFactor)
    {
        Id = id;
        FullName = fullName;
        BirthDate = birthDate;
        Gender = gender;
        Weight = weight;
        BloodType = bloodType;
        RgFactor = rgFactor;
    }
    public int Id { get; private set; }
    public string FullName { get; private set; }
    public string Email { get; private set; }
    public DateTime BirthDate { get; private set; }
    public Gender Gender { get; private set; }
    public double Weight { get; private set; }
    public BloodType BloodType { get; private set; }
    public RgFactor RgFactor { get; private set; }

    public static DonorViewModel FromEntity(Donor donor)
    {
        return new DonorViewModel(donor.Id, donor.FullName, donor.BirthDate, donor.Gender, donor.Weight, donor.BloodType, donor.RgFactor);
    }
}
