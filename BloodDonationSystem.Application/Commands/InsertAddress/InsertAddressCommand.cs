using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Application.Models;
using MediatR;

namespace BloodDonationSystem.Application.Commands.InsertAddress;
public class InsertAddressCommand : IRequest<AddressViewModel>
{
    public int DonorId { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Cep { get; set; }

    public Address ToEntity()
    {
        return new Address(DonorId, Street, City, State, Cep);
    }
}
