using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AzureStore.WebJobs
{
    public static class EmailSender
    {
        public static void Send(string fromEmail, string fromName, string message)
        {
            SmtpClient client = new SmtpClient("127.0.0.1");

            var mailMessage = new MailMessage(
                from: new MailAddress(fromEmail, fromName),
                to: new MailAddress("enquiries@azurestore.com", "Enquiries"));

            mailMessage.Subject = "Feedback from store";
            mailMessage.Body = message;

            client.Send(mailMessage);
        }
    }
}
