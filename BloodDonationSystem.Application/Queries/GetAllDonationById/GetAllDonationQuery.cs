using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Application.Models;
using MediatR;

namespace BloodDonationSystem.Application.Queries.GetAllDonationById;
public class GetAllDonationQuery : IRequest<ResultViewModel<List<DonationViewModel>>>
{
    public GetAllDonationQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
