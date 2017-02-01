using Microsoft.AspNet.SignalR;
using RabbitMQ.Client.Events;
using RabbitMQManeger.RabbitMQClient;
using RabbitMQManeger.RabbitMQConsumer;
using SettingsService.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SettingsService.Hubs
{
    public class ConsumerSettingsHub : Hub
    {
        private SettingContext db = new SettingContext();
        const string ADDRESSE = "10.10.41.178";
        public void Connect(string userName)
        {
            IConsumerRabbitMQ consumerRabbit = new ConsumerRabbitMQ();
            consumerRabbit.InitConnection(new RabbitMQManager.UserRabbitMQ("user", "password", ADDRESSE));
            consumerRabbit.EventRecividedMessage += Received;
            

            foreach (var oneSettings in db.SettingForOneQueues.ToList())
            {
                consumerRabbit.Subscribe(oneSettings.Queue);
            }
        }

        private void Received(BasicDeliverEventArgs eventArgs)
        {
            string userAddresant = eventArgs.BasicProperties.UserId;
            var body = eventArgs.Body;
            var message = Encoding.UTF8.GetString(body);
            IClientRabbitMQ client = new ClientRabbitMQ();
            client.InitConnection(new RabbitMQManager.UserRabbitMQ("user", "password", ADDRESSE));
            foreach (var oneSettings in db.SettingForOneQueues.FirstOrDefault(x => x.Queue == eventArgs.RoutingKey).QueusSettings.ToList())
            {
                client.Send(oneSettings.QueueNew, message);
            }
            Clients.All.addMessage(eventArgs.RoutingKey, message);
        }
    }
}