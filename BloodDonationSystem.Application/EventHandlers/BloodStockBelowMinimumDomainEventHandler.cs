using BloodDonationSystem.Core.Events;
using BloodDonationSystem.Core.Repositories;
using MediatR;

namespace BloodDonationSystem.Application.EventHandlers;
public class BloodStockBelowMinimumDomainEventHandler : INotificationHandler<BloodStockBelowMinimumDomainEvent>
{
    private readonly IBrevoEmailService _emailService;

    public BloodStockBelowMinimumDomainEventHandler(IBrevoEmailService emailService)
    {
        _emailService = emailService;
    }
    public async Task Handle(BloodStockBelowMinimumDomainEvent notification, CancellationToken cancellationToken)
    {

        Console.WriteLine($"⚠️ Alerta: Estoque de {notification.BloodType}{notification.RgFactor} abaixo do mínimo. Atual: {notification.AmountMl}ml / Mínimo: {notification.MinimumAmountMl}ml.");
    }
}
