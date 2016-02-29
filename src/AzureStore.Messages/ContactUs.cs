using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AzureStore.Messages
{
    [DataContract]
    public class ContactUsMessage
    {
        [DataMember]
        public string FromEmail { get; private set; }
        [DataMember]
        public string FromName { get; private set; }
        [DataMember]
        public string Message { get; private set; }

        public ContactUsMessage()
        {
        }

        public ContactUsMessage(string fromEmail, string fromName, string message)
        {
            this.FromEmail = fromEmail;
            this.FromName = fromName;
            this.Message = message;
        }

        public override string ToString()
        {
            return "Email:" + FromEmail + " Name:" + FromName + " Message:" + Message;
        }

    }
}
