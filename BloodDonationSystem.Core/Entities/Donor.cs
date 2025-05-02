namespace BloodDonationSystem.Application.Entities;
public class Donor
{
    public Donor(string fullName, DateTime birthDate, string gender, double weight, string bloodType, string rgFactor)
    {
        FullName = fullName;
        BirthDate = birthDate;
        Gender = gender;
        Weight = weight;
        BloodType = bloodType;
        RgFactor = rgFactor;
        IsDeleted = false;
    }
    public int Id { get; private set; }
    public string FullName { get; private set; }
    public DateTime BirthDate {  get; private set; }
    public string Gender {  get; private set; }
    public double Weight { get; private set; }
    public string BloodType {  get; private set; }
    public string RgFactor {  get; private set; }
    public bool IsDeleted {  get; private set; }
    public List<Donation> Donations { get; private set; } = new List<Donation>();
    public Address? Address {  get; private set; }

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

    public void Delete()
    {
        IsDeleted = true;
    }

    public void Restore()
    {
        IsDeleted = false;
    }
}
