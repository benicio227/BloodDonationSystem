using BloodDonationSystem.Core.Entities;
using BloodDonationSystem.Core.Enums;

namespace BloodDonationSystem.Application.Entities;
public class Donor
{
    public Donor(string fullName, string email, DateTime birthDate, Gender gender, double weight, BloodType bloodType, RgFactor rgFactor, int userId)
    {
        FullName = fullName;
        Email = email;
        BirthDate = birthDate;
        Gender = gender;
        Weight = weight;
        BloodType = bloodType;
        RgFactor = rgFactor;
        UserId = userId;
        IsDeleted = false;
    }
    public int Id { get; private set; }
    public int UserId {  get; private set; }
    public string FullName { get; private set; }
    public string Email { get; private set; }
    public DateTime BirthDate {  get; private set; }
    public Gender Gender {  get; private set; }
    public double Weight { get; private set; }
    public BloodType BloodType {  get; private set; }
    public RgFactor RgFactor {  get; private set; }
    public bool IsDeleted {  get; private set; }
    public List<Donation> Donations { get; private set; } = new List<Donation>();
    public Address? Address {  get; private set; }
    public User? User {  get; private set; }
    public Appointment? Appointment {  get; private set; }

    public void UpdateWeight(double weight)
    {
        Weight = weight;
    }

    public void UpdateBloodType(BloodType bloodType)
    {
        BloodType = bloodType;
    }

    public void UpdateRgFactor(RgFactor rgFactor)
    {
        RgFactor = rgFactor;
    }

    public void Delete()
    {
        IsDeleted = true;
    }

    public void Restore()
    {
        IsDeleted = false;
    }
}
