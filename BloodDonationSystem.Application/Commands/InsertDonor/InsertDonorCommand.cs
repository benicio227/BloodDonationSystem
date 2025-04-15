using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Application.Models;
using MediatR;

namespace BloodDonationSystem.Application.Commands.InsertDonor;
public class InsertDonorCommand : IRequest<DonorViewModel>
{
    public string FullName { get; private set; }
    public string Email { get; private set; }
    public DateTime BirthDate { get; private set; }
    public string Gender { get; private set; }
    public double Weight { get; private set; }
    public string BloodType { get; private set; }
    public string RgFactor { get; private set; }

    public Donor ToEntity()
    {
        return new Donor(FullName, Email, BirthDate, Gender, Weight, BloodType, RgFactor);
    }
}
