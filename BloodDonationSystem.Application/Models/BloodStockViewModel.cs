using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Core.Enums;

namespace BloodDonationSystem.Application.Models;
public class BloodStockViewModel 
{
    public BloodStockViewModel(int id, BloodType bloodType, RgFactor rgFactor, int amountMl)
    {
        Id = id;
        BloodType = bloodType;
        RgFactor = rgFactor;
        AmountMl = amountMl;
    }
    public int Id { get; private set; }
    public BloodType BloodType { get; private set; }
    public RgFactor RgFactor { get; private set; }
    public int AmountMl { get; private set; }

    public static BloodStockViewModel FromEntity(BloodStock bloodStock)
    {
        return new BloodStockViewModel(bloodStock.Id, bloodStock.BloodType, bloodStock.RgFactor, bloodStock.AmountMl);
    }
}
