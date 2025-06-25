using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Enums;
using MediatR;

namespace BloodDonationSystem.Application.Commands.InsertDonor;
public class InsertDonorCommand : IRequest<ResultViewModel<DonorViewModel>>
{
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Email { get; set; }
    public Gender Gender { get; set; }
    public double Weight { get; set; }
    public BloodType BloodType { get; set; }
    public RgFactor RgFactor { get; set; }
    public int UserId {  get; set; }

    public Donor ToEntity()
    {
        return new Donor(FullName, Email, BirthDate, Gender, Weight, BloodType, RgFactor, UserId);
    }
}
