using RabbitMQ.Client;
using RabbitMQManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQManeger.RabbitMQClient
{
    public class ClientRabbitMQ : BaseRabbitMQ, IClientRabbitMQ
    {
        public void Send(string queue, string message)
        {
            this.channel.QueueDeclare(queue: queue,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
            var body = Encoding.UTF8.GetBytes(message);

            this.channel.BasicPublish(exchange: "",
                                     routingKey: queue,
                                     basicProperties: null,
                                     body: body);
        }
    }
}
