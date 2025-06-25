using BloodDonationSystem.Core.Events;
using BloodDonationSystem.Core.Repositories;
using MediatR;

namespace BloodDonationSystem.Application.EventHandlers
{
    public class DonationRegisteredDomainEventHandler : INotificationHandler<DonationRegisteredDomainEvent>
    {
        private readonly IBrevoEmailService _emailService;

        public DonationRegisteredDomainEventHandler(IBrevoEmailService emailService)
        {
            _emailService = emailService;
        }
        public async Task Handle(DonationRegisteredDomainEvent notification, CancellationToken cancellationToken)
        {
            var htmlContent = $"<p>Olá {notification.FullName},</p><p>Obrigado por sua doação de <strong>{notification.AmountMl}ml</strong>. Você está salvando vidas! ❤️</p>";

            await _emailService.SendEmail(
                toEmail: notification.Email,
                toName: notification.FullName,
                subject: "Confirmação de Agendamento de Doação",
                htmlContent: htmlContent
            );
        }
    }
}
