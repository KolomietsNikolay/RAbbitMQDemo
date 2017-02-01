using RabbitMQManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQManeger.RabbitMQConsumer
{
    public interface IConsumerRabbitMQ : IBaseRabbitMQ
    {
        void Subscribe(string queue);

        event Recivied EventRecividedMessage;
    }
}
