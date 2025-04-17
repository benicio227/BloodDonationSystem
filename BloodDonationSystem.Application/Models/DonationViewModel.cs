using BloodDonationSystem.Application.Entities;

namespace BloodDonationSystem.Application.Models;
public class DonationViewModel
{
    public DonationViewModel(int id, int donorId, int amountMl)
    {
        Id = id;
        DonorId = donorId;
        AmountMl = amountMl;
        DonationDate = DateTime.Now;
    }
    public int Id { get; private set; }
    public int DonorId { get; private set; }
    public DateTime DonationDate { get; private set; }
    public int AmountMl { get; private set; }
    public Donor? Donor { get; private set; }

    public static DonationViewModel FromEntity(Donation donation)
    {
        return new DonationViewModel(donation.Id, donation.DonorId, donation.AmountMl);
    }
}
