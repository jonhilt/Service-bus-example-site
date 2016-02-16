using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using System.Net.Mail;
using System.Runtime.Serialization;

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

            var mailMessage = new MailMessage(
                from: new MailAddress(fromEmail, fromName), 
                to: new MailAddress("enquiries@azurestore.com", "Enquiries"));

            mailMessage.Subject = "Feedback from store";
            mailMessage.Body = message;

            client.Send(mailMessage);
        }
    }

    public class AzureServiceBusEmailSender : IEmailSender
    {
        private const string connectionString = "Endpoint=sb://awesomestore.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=NesH71Uj+Aqo/9UvzfXUSbQMvcFPmxEK08n/TowMGTc=";
        private const string queueName = "contact-us";

        public void Send(string fromEmail, string fromName, string message)
        {
            NamespaceManager namespaceManager = NamespaceManager.CreateFromConnectionString(connectionString);
                        
            if (!namespaceManager.QueueExists(queueName))
                namespaceManager.CreateQueue(queueName);

            var queueClient = QueueClient.CreateFromConnectionString(connectionString, queueName);
            queueClient.Send(new BrokeredMessage(new SendEmailCommand(fromEmail, fromName, message)));
        }
    }

    [DataContract]
    public class SendEmailCommand
    {
        [DataMember]
        public string FromEmail { get; private set; }
        [DataMember]
        public string FromName { get; private set; }
        [DataMember]
        public string Message { get; private set; }

        public SendEmailCommand()
        {
        }

        public SendEmailCommand(string fromEmail, string fromName, string message)
        {
            this.FromEmail = fromEmail;
            this.FromName = fromName;
            this.Message = message;
        }

      
    }
}
