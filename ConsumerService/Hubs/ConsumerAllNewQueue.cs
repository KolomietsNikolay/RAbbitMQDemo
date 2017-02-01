using Microsoft.AspNet.SignalR;
using RabbitMQ.Client.Events;
using RabbitMQManeger.RabbitMQConsumer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ConsumerService.Hubs
{
    public class ConsumerAllNewQueue : Hub
    {
        const string ADDRESSE = "10.10.41.178";
        private List<string> QUEUES = new List<string>() { "helloCopy", "retroCopy", "helloAlternative", "helloFirst", "retroTest", "chatCopy" };

        public void Connect(string userName)
        {
            IConsumerRabbitMQ consumerRabbit = new ConsumerRabbitMQ();
            consumerRabbit.InitConnection(new RabbitMQManager.UserRabbitMQ("user", "password", ADDRESSE));
            consumerRabbit.EventRecividedMessage += Received;


            foreach (var oneQueue in QUEUES)
            {
                consumerRabbit.Subscribe(oneQueue);
            }
        }

        private void Received(BasicDeliverEventArgs eventArgs)
        {
            string userAddresant = eventArgs.BasicProperties.UserId;
            var body = eventArgs.Body;
            var message = Encoding.UTF8.GetString(body);

            Clients.All.addMessage(eventArgs.RoutingKey, message);
        }
    }
}