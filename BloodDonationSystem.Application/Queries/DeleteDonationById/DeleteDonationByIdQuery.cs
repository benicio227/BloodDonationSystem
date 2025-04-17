using BloodDonationSystem.Application.Models;
using MediatR;

namespace BloodDonationSystem.Application.Queries.DeleteDonationById;
public class DeleteDonationByIdQuery : IRequest<Unit>
{
    public DeleteDonationByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
