using MediatR;

namespace BloodDonationSystem.Application.Queries.DeleteAddressById;
public class DeleteAddressByIdQuery : IRequest<Unit>
{
    public DeleteAddressByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
