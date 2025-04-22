namespace BloodDonationSystem.Application.Entities;
public class Donation
{
    public Donation(int donorId, int amountMl)
    {
        DonorId = donorId;
        AmountMl = amountMl;
        DonationDate = DateTime.Now;
        IsDeleted = false;
    }
    public int Id { get; private set; }
    public int DonorId {  get; private set; }
    public DateTime DonationDate { get; private set; }
    public int AmountMl {  get; private set; }
    public bool IsDeleted {  get; private set; }
    public Donor? Donor { get; private set; }

    public void Delete()
    {
        IsDeleted = true;
    }

    public void Restore()
    {
        IsDeleted = false;
    }
}
