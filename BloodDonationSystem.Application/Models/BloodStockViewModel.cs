using BloodDonationSystem.Application.Entities;

namespace BloodDonationSystem.Application.Models;
public class BloodStockViewModel 
{
    public BloodStockViewModel(int id, string bloodType, string rgFactor, int amountMl)
    {
        Id = id;
        BloodType = bloodType;
        RgFactor = rgFactor;
        AmountMl = amountMl;
    }
    public int Id { get; private set; }
    public string BloodType { get; private set; }
    public string RgFactor { get; private set; }
    public int AmountMl { get; private set; }

    public static BloodStockViewModel FromEntity(BloodStock bloodStock)
    {
        return new BloodStockViewModel(bloodStock.Id, bloodStock.BloodType, bloodStock.RgFactor, bloodStock.AmountMl);
    }
}
