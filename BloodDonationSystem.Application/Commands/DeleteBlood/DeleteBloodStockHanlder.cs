using BloodDonationSystem.Core.Repositories;
using MediatR;

namespace BloodDonationSystem.Application.Commands.DeleteBlood;
public class DeleteBloodStockHanlder : IRequestHandler<DeleteBloodStockCommand, Unit>
{
    private readonly IBloodStockRepository _repository;

    public DeleteBloodStockHanlder(IBloodStockRepository repository)
    {
        _repository = repository;
    }
    public async Task<Unit> Handle(DeleteBloodStockCommand request, CancellationToken cancellationToken)
    {
        await _repository.Delete(request.Id);

        return Unit.Value;
    }
}
