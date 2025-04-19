using BloodDonationSystem.Application.Models;
using MediatR;

namespace BloodDonationSystem.Application.Queries.GetBloodStockById;
public class GetBloodStockByIdQuery : IRequest<ResultViewModel<BloodStockViewModel>>
{
    public GetBloodStockByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
