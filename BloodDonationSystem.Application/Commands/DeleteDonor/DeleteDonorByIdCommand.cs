using BloodDonationSystem.Application.Models;
using MediatR;

namespace BloodDonationSystem.Application.Commands.DeleteDonor;
public class DeleteDonorByIdCommand : IRequest<ResultViewModel>
{
    public DeleteDonorByIdCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
