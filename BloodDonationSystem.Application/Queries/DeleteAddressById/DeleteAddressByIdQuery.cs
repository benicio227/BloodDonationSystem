using BloodDonationSystem.Application.Models;
using MediatR;

namespace BloodDonationSystem.Application.Queries.DeleteAddressById;
public class DeleteAddressByIdQuery : IRequest<ResultViewModel<AddressViewModel>>
{
    public DeleteAddressByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
