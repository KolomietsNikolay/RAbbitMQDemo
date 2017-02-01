using RabbitMQManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQManeger.RabbitMQClient
{
    public interface IClientRabbitMQ : IBaseRabbitMQ
    {
        void Send(string queue, string message);
    }
}
