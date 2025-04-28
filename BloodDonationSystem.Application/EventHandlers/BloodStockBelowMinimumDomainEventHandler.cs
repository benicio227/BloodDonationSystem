using BloodDonationSystem.Core.Events;
using MediatR;

namespace BloodDonationSystem.Application.EventHandlers;
public class BloodStockBelowMinimumDomainEventHandler : INotificationHandler<BloodStockBelowMinimumDomainEvent>
{
    public Task Handle(BloodStockBelowMinimumDomainEvent notification, CancellationToken cancellationToken)
    {

        Console.WriteLine($"⚠️ Alerta: Estoque de {notification.BloodType}{notification.RgFactor} abaixo do mínimo. Atual: {notification.AmountMl}ml / Mínimo: {notification.MinimumAmountMl}ml.");

        return Task.CompletedTask;
    }
}
