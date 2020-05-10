using System.Linq;
using System.Security.Authentication;
using MimeKit;

namespace James_MVC.Models
{
    public class MailKitEmailService : IEmailService
    {
        private readonly EmailServerConfiguration _eConfig;

        public MailKitEmailService(EmailServerConfiguration config)
        {
            _eConfig = config;
        }

        [System.Obsolete]
        public void Send(EmailMessage msg)
        {
            var message = new MimeMessage();
            message.To.AddRange(msg.ToAddresses.Select(x => new MailboxAddress(x.Name, x.Address)));
            message.From.AddRange(msg.FromAddresses.Select(x => new MailboxAddress(x.Name, x.Address)));

            message.Subject = msg.Subject;

            message.Body = new TextPart("plain")
            {
                Text = msg.Content
            };

            using var client = new MailKit.Net.Smtp.SmtpClient();
            client.SslProtocols = SslProtocols.Ssl3 | SslProtocols.Tls | SslProtocols.Tls11 | SslProtocols.Tls12 | SslProtocols.Tls13;
            client.Connect(_eConfig.SmtpServer, _eConfig.SmtpPort);

            client.AuthenticationMechanisms.Remove("XOAUTH2");

            client.Authenticate(_eConfig.SmtpUsername, _eConfig.SmtpPassword);

            client.Send(message);
            client.Disconnect(true);
        }
    }
}
