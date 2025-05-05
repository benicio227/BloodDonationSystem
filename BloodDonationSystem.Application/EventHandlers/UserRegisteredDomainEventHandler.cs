using BloodDonationSystem.Core.Events;
using BloodDonationSystem.Core.Repositories;
using MediatR;

namespace BloodDonationSystem.Application.EventHandlers;
public class UserRegisteredDomainEventHandler : INotificationHandler<UserRegisteredDomainEvent>
{
    private readonly IBrevoEmailService _emailService;

    public UserRegisteredDomainEventHandler(IBrevoEmailService emailService)
    {
        _emailService = emailService;
    }
    public async Task Handle(UserRegisteredDomainEvent notification, CancellationToken cancellationToken)
    {
        var htmlContent = $@"
            <p>Olá {notification.FullName},</p>
            <p>Seu cadastro foi realizado com sucesso no sistema de doação de sangue.</p>
            <p>Obrigado por fazer parte dessa corrente do bem! ❤️</p>";

        await _emailService.SendEmail(
            toEmail: notification.Email,
            toName: notification.FullName,
            subject: "Cadastro realizado com sucesso",
            htmlContent: htmlContent
        );
    }
}
