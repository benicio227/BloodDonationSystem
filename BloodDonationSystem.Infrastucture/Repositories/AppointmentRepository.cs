using BloodDonationSystem.Core.Entities;
using BloodDonationSystem.Core.Enums;
using BloodDonationSystem.Core.Repositories;
using BloodDonationSystem.Infrastucture.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationSystem.Infrastucture.Repositories;
public class AppointmentRepository : IAppointmentRepository
{
    private readonly BloodDonationSystemDbContext _context;

    public AppointmentRepository(BloodDonationSystemDbContext context)
    {
        _context = context;
    }
    public async Task<Appointment> Add(Appointment appointment)
    {
        _context.Appointments.Add(appointment);
        await _context.SaveChangesAsync();

        return appointment;
    }

    public async Task<bool> ExistsConflict(DateTime scheduleAt, LocationType location)
    {
        return await _context.Appointments.AnyAsync(a =>
            a.Location == location &&
            a.ScheduledAt.Year == scheduleAt.Year &&
            a.ScheduledAt.Month == scheduleAt.Month &&
            a.ScheduledAt.Day == scheduleAt.Day &&
            a.ScheduledAt.Hour == scheduleAt.Hour &&
            a.ScheduledAt.Minute == scheduleAt.Minute);
    }
}
