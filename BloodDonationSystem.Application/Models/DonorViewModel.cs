﻿using BloodDonationSystem.Application.Entities;

namespace BloodDonationSystem.Application.Models;
public class DonorViewModel
{
    public DonorViewModel(int id, string fullName, DateTime birthDate, string gender, double weight, string bloodType, string rgFactor)
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
    public string Gender { get; private set; }
    public double Weight { get; private set; }
    public string BloodType { get; private set; }
    public string RgFactor { get; private set; }

    public static DonorViewModel FromEntity(Donor donor)
    {
        return new DonorViewModel(donor.Id, donor.FullName, donor.BirthDate, donor.Gender, donor.Weight, donor.BloodType, donor.RgFactor);
    }
}
