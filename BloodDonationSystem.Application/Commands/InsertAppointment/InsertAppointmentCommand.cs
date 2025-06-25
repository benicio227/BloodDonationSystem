using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Entities;
using BloodDonationSystem.Core.Enums;
using MediatR;
using System.Text.Json.Serialization;

namespace BloodDonationSystem.Application.Commands.InsertAppointment;
public class InsertAppointmentCommand : IRequest<ResultViewModel<AppointmentViewModel>>
{
    [JsonIgnore]
    public int DonorId {  get; set; }
    public DateTime ScheduledAt { get; set; }
    public LocationType Location { get; set; }

    public Appointment ToEntity()
    {
        return new Appointment(DonorId, ScheduledAt, Location);
    }
}
