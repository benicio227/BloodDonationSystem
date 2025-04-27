using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Application.Models;
using MediatR;

namespace BloodDonationSystem.Application.Commands;
public class UpdateDonorCommand : IRequest<ResultViewModel>
{
    public int Id {  get; set; }
    public string Email { get; set; }
    public double Weight { get; set; }
    public string BloodType { get; set; }
    public string RgFactor { get; set; }
}
