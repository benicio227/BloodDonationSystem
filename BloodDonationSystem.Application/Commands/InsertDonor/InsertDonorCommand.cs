using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Application.Models;
using MediatR;

namespace BloodDonationSystem.Application.Commands.InsertDonor;
public class InsertDonorCommand : IRequest<ResultViewModel<DonorViewModel>>
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public string Gender { get; set; }
    public double Weight { get; set; }
    public string BloodType { get; set; }
    public string RgFactor { get; set; }

    public Donor ToEntity()
    {
        return new Donor(FullName, Email, BirthDate, Gender, Weight, BloodType, RgFactor);
    }
}
