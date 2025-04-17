using BloodDonationSystem.Application.Models;
using MediatR;

namespace BloodDonationSystem.Application.Queries.GetAllBloodStock;
public class GetAllBloodStockQuery : IRequest<List<BloodStockViewModel>>
{
}
