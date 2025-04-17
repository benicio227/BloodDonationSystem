using BloodDonationSystem.Application.Models;
using MediatR;
using System.Runtime.InteropServices;

namespace BloodDonationSystem.Application.Queries.GetDonationById;
public class GetDonationByIdQuery : IRequest<DonationViewModel>
{
    public GetDonationByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
