namespace BloodDonationSystem.Application.Entities;
public class BloodStock
{
    public BloodStock(string bloodType, string rgFactor, int amountMl)
    {
        BloodType = bloodType;
        RgFactor = rgFactor;
        AmountMl = amountMl;
    }
    public int Id { get; private set; }
    public string BloodType {  get; private set; }
    public string RgFactor {  get; private set; }
    public int AmountMl { get; private set; }

    public void AddAmount(int amount)
    {
        AmountMl += amount;
    }
}
