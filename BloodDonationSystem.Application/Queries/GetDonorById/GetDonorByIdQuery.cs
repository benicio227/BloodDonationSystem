using BloodDonationSystem.Application.Models;
using MediatR;

namespace BloodDonationSystem.Application.Queries.GetDonorById;
public class GetDonorByIdQuery : IRequest<ResultViewModel<DonorViewModel>>
{
    public GetDonorByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
