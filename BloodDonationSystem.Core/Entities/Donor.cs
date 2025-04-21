namespace BloodDonationSystem.Application.Entities;
public class Donor
{
    public Donor(string fullName, string email, DateTime birthDate, string gender, double weight, string bloodType, string rgFactor)
    {
        FullName = fullName;
        Email = email;
        BirthDate = birthDate;
        Gender = gender;
        Weight = weight;
        BloodType = bloodType;
        RgFactor = rgFactor;
    }
    public int Id { get; private set; }
    public string FullName { get; private set; }
    public string Email {  get; private set; }
    public DateTime BirthDate {  get; private set; }
    public string Gender {  get; private set; }
    public double Weight { get; private set; }
    public string BloodType {  get; private set; }
    public string RgFactor {  get; private set; }
    public List<Donation> Donations { get; private set; } = new List<Donation>();
    public Address? Address {  get; private set; }

    public void UpdateEmail(string email)
    {
        Email = email;
    }

    public void UpdateWeight(double weight)
    {
        Weight = weight;
    }

    public void UpdateBloodType(string bloodType)
    {
        BloodType = bloodType;
    }

    public void UpdateRgFactor(string rgFactor)
    {
        RgFactor = rgFactor;
    }
}
