using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQManeger.RabbitMQConsumer
{
    public delegate void Recivied(BasicDeliverEventArgs ea);

    public class ConsumerRabbitMQ : BaseRabbitMQ, IConsumerRabbitMQ
    {
        public event Recivied EventRecividedMessage;

        public void Subscribe(string queue)
        {
            this.channel.QueueDeclare(queue: queue,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

            var consumer = new EventingBasicConsumer(this.channel);
            consumer.Received += (model, ea) =>
            {
                this.EventRecividedMessage(ea);
            };

            channel.BasicConsume(queue: queue,
                                noAck: true,
                                consumer: consumer);

        }
    }
}
