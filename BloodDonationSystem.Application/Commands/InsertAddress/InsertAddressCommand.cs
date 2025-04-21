using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Application.Models;
using MediatR;

namespace BloodDonationSystem.Application.Commands.InsertAddress;
public class InsertAddressCommand : IRequest<ResultViewModel<AddressViewModel>>
{
    public int DonorId { get; set; }
    public string Cep { get; set; }
    public string? Street { get; set; }
}
