using BloodDonationSystem.Application.Models;
using MediatR;

namespace BloodDonationSystem.Application.Commands.DeleteAddressById;
public class DeleteAddressByIdQuery : IRequest<ResultViewModel>
{
    public DeleteAddressByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
