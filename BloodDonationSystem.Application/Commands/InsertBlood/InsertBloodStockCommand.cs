using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Application.Models;
using MediatR;

namespace BloodDonationSystem.Application.Commands.InsertBlood;
public class InsertBloodStockCommand : IRequest<ResultViewModel<BloodStockViewModel>>
{
    public string BloodType { get; set; }
    public string RgFactor { get; set; }
    public int AmountMl { get; set; }
    public int MinimumAmountMl {  get; set; }

    public BloodStock ToEntity()
    {
        return new BloodStock(BloodType, RgFactor, AmountMl, MinimumAmountMl);
    }
}
