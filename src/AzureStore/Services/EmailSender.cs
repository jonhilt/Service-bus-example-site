using AzureStore.Messages;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;

namespace AzureStore.Services
{
    public interface IContactUs
    {
        void SubmitDetails(string fromEmail, string fromName, string message);
    }      

    public class AzureContactUs : IContactUs
    { 
        public void SubmitDetails(string fromEmail, string fromName, string message)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=azurestorestorage;AccountKey=mY0Iw/nRDFaZgpviRSBs28n7IjZZMG/EBL3phAfTl8dc7xBWhaaVJzgIwdH9mmaficSxsW2NsdHc2UTyHyntJg==");
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueClient.GetQueueReference("contact-us");
            queue.CreateIfNotExists();

            var contactUsMessage = new ContactUsMessage(fromEmail, fromName, message);
            var serialized = JsonConvert.SerializeObject(contactUsMessage);
            queue.AddMessage(new CloudQueueMessage(serialized));

        }
    }    

}
