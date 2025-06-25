using BloodDonationSystem.Core.Events;
using BloodDonationSystem.Core.Repositories;
using MediatR;

namespace BloodDonationSystem.Application.EventHandlers;
public class AppointmentRegisteredDomainEventHandler : INotificationHandler<AppointmentRegisteredDomainEvent>
{
    private readonly IBrevoEmailService _emailService;

    public AppointmentRegisteredDomainEventHandler(IBrevoEmailService brevoEmail)
    {
        _emailService = brevoEmail;
    }
    public async Task Handle(AppointmentRegisteredDomainEvent notification, CancellationToken cancellationToken)
    {
        try
        {
            var htmlContent = $@"
    <html>
        <body style='font-family: Arial, sans-serif; color: #333;'>
            <h2>Confirmação de Agendamento</h2>
            <p>Olá <strong>{notification.FullName}</strong>,</p>
            <p>Seu agendamento foi confirmado com sucesso!</p>
            <p><strong>Data:</strong> {notification.ScheduledAt:dd/MM/yyyy HH:mm}</p>
            <p><strong>Local:</strong> {notification.Location}</p>
            <p>Por favor, chegue com 15 minutos de antecedência e leve um documento com foto.</p>
            <br/>
            <p>Obrigado por fazer a diferença com a sua doação! 💉❤️</p>
            <p>Equipe Blood Donation System</p>
        </body>
    </html>";

            await _emailService.SendEmail(
                toEmail: notification.Email,
                toName: notification.FullName,
                subject: "Confirmação de doação de sangue",
                htmlContent: htmlContent
            );
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Erro ao enviar e-mail de confirmação: {ex.Message}");
        }
    }
}
