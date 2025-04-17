using MediatR;

namespace BloodDonationSystem.Application.Commands.DeleteBlood;
public class DeleteBloodStockCommand : IRequest<Unit>
{
    public DeleteBloodStockCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
