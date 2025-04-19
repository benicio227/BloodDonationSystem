using BloodDonationSystem.Application.Models;
using MediatR;

namespace BloodDonationSystem.Application.Commands.DeleteBlood;
public class DeleteBloodStockCommand : IRequest<ResultViewModel<BloodStockViewModel>>
{
    public DeleteBloodStockCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
