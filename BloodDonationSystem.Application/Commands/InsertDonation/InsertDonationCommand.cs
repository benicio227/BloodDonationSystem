using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Application.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace BloodDonationSystem.Application.Commands.InsertDonation;
public class InsertDonationCommand : IRequest<ResultViewModel<DonationViewModel>>
{
    [JsonIgnore]
    public int DonorId { get; set; }
    public int AmountMl { get; set; }


    public Donation ToEntity()
    {
        return new Donation(DonorId, AmountMl);
    }
}
