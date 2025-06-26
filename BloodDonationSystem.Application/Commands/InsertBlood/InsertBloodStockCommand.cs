using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Enums;
using MediatR;

namespace BloodDonationSystem.Application.Commands.InsertBlood;
public class InsertBloodStockCommand : IRequest<ResultViewModel<BloodStockViewModel>>
{
    public BloodType BloodType { get; set; }
    public RgFactor RgFactor { get; set; }
    public int AmountMl { get; set; }
    public int MinimumAmountMl {  get; set; }

    public BloodStock ToEntity()
    {
        return new BloodStock(BloodType, RgFactor, AmountMl, MinimumAmountMl);
    }
}
