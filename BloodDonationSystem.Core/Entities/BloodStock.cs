using BloodDonationSystem.Core.Enums;

namespace BloodDonationSystem.Application.Entities;
public class BloodStock
{
    public BloodStock(BloodType bloodType, RgFactor rgFactor, int amountMl, int minimumAmountMl)
    {
        BloodType = bloodType;
        RgFactor = rgFactor;
        AmountMl = amountMl;
        MinimumAmountMl = minimumAmountMl;
        IsDeleted = false;

    }
    public int Id { get; private set; }
    public BloodType BloodType {  get; private set; }
    public RgFactor RgFactor {  get; private set; }
    public int AmountMl { get; private set; }
    public int MinimumAmountMl {  get; private set; }
    public bool IsDeleted {  get; private set; }
    public void AddAmount(int amount)
    {
        AmountMl += amount;
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
 