using Demo.Application.Boundaries.Configuration;
using Demo.Application.Boundaries.MessageBus.Messages;
using Demo.MessageBus.Services;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace Demo.MessageBus.Email;

public class EmailService : IMessageService
{
    private readonly IConfigurationService configurationService;

    public EmailService(IConfigurationService configurationService)
    {
        this.configurationService = configurationService;
    }

    public void Send<T>(Message<T> message)
    {
        var configuration = configurationService.Get<EmailConfiguration>(message.Type);

        var emailMessage = new MimeMessage();

        emailMessage.From.Add(new MailboxAddress(null, configuration.From));
        emailMessage.To.AddRange(new List<MailboxAddress> { new MailboxAddress(null, configuration.To) });
        emailMessage.Subject = configuration.Subject;

        var bodyBuilder = new BodyBuilder
        {
            HtmlBody = Newtonsoft.Json.JsonConvert.SerializeObject(message.Payload)
        };
        emailMessage.Body = bodyBuilder.ToMessageBody();

        Send(emailMessage);
    }

    private void Send(MimeMessage message)
    {
        using var client = new SmtpClient();
        client.Connect("mail.lidozrh.ch", 25, SecureSocketOptions.None);
        client.Send(message);
        client.Disconnect(true);
    }
}
