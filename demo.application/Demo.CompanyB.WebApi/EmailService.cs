using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace Demo.CompanyB.WebApi;

public class EmailService
{
    private readonly IConfiguration configuration;

    public EmailService(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public void Send(Airport airport)
    {
        var emailMessage = new MimeMessage();

        emailMessage.From.Add(new MailboxAddress(null, configuration.GetValue<string>("from")));
        emailMessage.To.AddRange(new List<MailboxAddress> { new MailboxAddress(null, configuration.GetValue<string>("to")) });
        emailMessage.Subject = configuration.GetValue<string>("subject");

        var bodyBuilder = new BodyBuilder
        {
            HtmlBody = Newtonsoft.Json.JsonConvert.SerializeObject(airport)
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
