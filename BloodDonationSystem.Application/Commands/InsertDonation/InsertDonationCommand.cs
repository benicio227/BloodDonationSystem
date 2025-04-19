using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Application.Models;
using MediatR;

namespace BloodDonationSystem.Application.Commands.InsertDonation;
public class InsertDonationCommand : IRequest<ResultViewModel<DonationViewModel>>
{
    public int DonorId { get; set; }
    public int AmountMl { get; set; }


    public Donation ToEntity()
    {
        return new Donation(DonorId, AmountMl);
    }
}
