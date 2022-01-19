using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Logging;
using MimeKit;
using System.Threading.Tasks;

namespace DBook.EmailProviders
{
    public class GmailProvider : IProvider
    {
        MimeMessage message;
        SmtpClient smtp;
        ILogger<GmailProvider> log;
        public GmailProvider(ILogger<GmailProvider> logger)
        {
            message = new MimeMessage();

            log = logger;
        }
        public async Task Send(string receiver, string content, string sender = "")
        {
            using (smtp = new SmtpClient())
            {


                try
                {

                    smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);//465 
                }
                catch (SmtpCommandException ex)
                {
                    log.LogInformation("Error trying to connect: {0}", ex.Message);
                    log.LogInformation("\tStatusCode: {0}", ex.StatusCode);
                    return;
                }
                catch (SmtpProtocolException ex)
                {
                    log.LogInformation("Protocol error while trying to connect: {0}", ex.Message);
                    return;
                }
                MailboxAddress from = new MailboxAddress("admin", sender);
                message.From.Add(from);
                MailboxAddress to = new MailboxAddress("user", receiver);
                message.To.Add(to);
                message.Subject = "DBook Email Comfirmation";
                BodyBuilder body = new BodyBuilder();
                body.HtmlBody = content;
                body.TextBody = "Thanks for Comfirmation";
                message.Body = body.ToMessageBody();
                if (!smtp.IsConnected)
                {
                    log.LogInformation($"current SmtpServer Can't Connect ,imap.gmail.com ,993");
                    return;
                }

                await smtp.AuthenticateAsync(sender, "");

                if (!smtp.IsAuthenticated)
                {
                    log.LogInformation($"current Admin {sender} not Authenticated");
                    return;
                }


                smtp.Send(message);

                smtp.Disconnect(true);
                smtp.Dispose();

            }
        }
    }
}
