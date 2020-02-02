using System.Threading.Tasks;
using EmailSender.Domain.Interfaces;
using EmailSender.Dtos;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace EmailSender.Domain
{
    public class Sender : ISender
    {
        private readonly string FROM_EMAIL;
        private readonly string FROM_EMAIL_PASSWORD;
        private readonly string FROM_EMAIL_NAME;
        private readonly string SERVER;
        private readonly int PORT;
        public Sender(IConfiguration configuration)
        {
            //From Email
            FROM_EMAIL = configuration["EmailSender:Email"];
            FROM_EMAIL_PASSWORD = configuration["EmailSender:Password"];
            FROM_EMAIL_NAME = configuration["EmailSender:Name"];

            //Server Configuration
            SERVER = configuration["EmailSender:Server"];
            PORT = int.Parse(configuration["EmailSender:Port"]);
        }
        public async Task SendEmailAsync(Email email)
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress(FROM_EMAIL_NAME, FROM_EMAIL));
            mimeMessage.To.Add(new MailboxAddress(email.NameOfRecipient, email.Recipient));
            mimeMessage.Subject = email.Subject;
            var builder = new BodyBuilder ();

            if (email.Attachment != null)
            {
                builder.Attachments.Add(email.Attachment.Name,
                    email.Attachment.File, email.Attachment.ContentType);
            }

            builder.HtmlBody = email.Message;
            mimeMessage.Body = builder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.Connect(SERVER, PORT, false);
                client.Authenticate(
                    FROM_EMAIL,
                    FROM_EMAIL_PASSWORD
                );
                await client.SendAsync(mimeMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}