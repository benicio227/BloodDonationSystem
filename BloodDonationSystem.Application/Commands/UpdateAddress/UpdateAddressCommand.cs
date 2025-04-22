using BloodDonationSystem.Application.Models;
using MediatR;

namespace BloodDonationSystem.Application.Commands.UpdateAddress;
public class UpdateAddressCommand : IRequest<ResultViewModel>
{
    public int Id { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
}
