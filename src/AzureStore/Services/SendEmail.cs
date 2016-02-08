using System.Net.Mail;

namespace AzureStore.Services
{
    public interface IEmailSender
    {
        void Send(string fromEmail, string fromName, string message);
    }

    public class EmailSender : IEmailSender
    {
        public void Send(string fromEmail, string fromName, string message)
        {
            SmtpClient client = new SmtpClient("127.0.0.1");

            var mailMessage = new MailMessage(from: new MailAddress(fromEmail, fromName), to: new MailAddress("enquiries@azurestore.com", "Enquiries"));
            mailMessage.Subject = "Feedback from store";
            mailMessage.Body = message;

            client.Send(mailMessage);
        }
    }
}
