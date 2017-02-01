using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQManager
{
    public abstract class BaseRabbitMQ : IBaseRabbitMQ
    {
        protected ConnectionFactory factory;
        protected IConnection connection;
        protected IModel channel;

        public void InitConnection(UserRabbitMQ user)
        {
            this.factory = new ConnectionFactory();
            factory.UserName = user.UserName;
            factory.Password = user.Password;
            factory.VirtualHost = "/";
            factory.Protocol = Protocols.DefaultProtocol;
            factory.HostName = user.HostName;
            factory.Port = user.Port;
            connection = factory.CreateConnection();
            this.channel = connection.CreateModel();
        }
    }
}
