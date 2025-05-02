using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Repositories;
using MediatR;

namespace BloodDonationSystem.Application.Commands.InsertDonor;
public class InsertDonorHandler : IRequestHandler<InsertDonorCommand, ResultViewModel<DonorViewModel>>
{
    private readonly IDonorRepository _repository;

    public InsertDonorHandler(IDonorRepository repository)
    {
        _repository = repository;
    }
    public async Task<ResultViewModel<DonorViewModel>> Handle(InsertDonorCommand request, CancellationToken cancellationToken)
    {
        //var donorExist = await _repository.GetByEmail(request.Email);

        //if (donorExist is not null)
        //{
        //    return ResultViewModel<DonorViewModel>.Error("Já existe um doador com esse E-mail.");
        //}

        var donorEntity = request.ToEntity();

        await _repository.Add(donorEntity);

        var model = DonorViewModel.FromEntity(donorEntity);

        return ResultViewModel<DonorViewModel>.Success(model);
    }
}
