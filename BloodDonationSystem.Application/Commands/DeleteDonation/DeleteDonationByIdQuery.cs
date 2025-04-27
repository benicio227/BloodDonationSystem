using BloodDonationSystem.Application.Models;
using MediatR;

namespace BloodDonationSystem.Application.Commands.DeleteDonation;
public class DeleteDonationByIdQuery : IRequest<ResultViewModel>
{
    public DeleteDonationByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
