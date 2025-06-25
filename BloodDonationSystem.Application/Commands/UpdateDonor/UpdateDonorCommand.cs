using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Enums;
using MediatR;

namespace BloodDonationSystem.Application.Commands;
public class UpdateDonorCommand : IRequest<ResultViewModel>
{
    public int Id {  get; set; }
    public string Email { get; set; }
    public double Weight { get; set; }
    public BloodType BloodType { get; set; }
    public RgFactor RgFactor { get; set; }
}
