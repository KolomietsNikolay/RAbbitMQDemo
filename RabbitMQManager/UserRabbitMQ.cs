using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQManager
{
    public class UserRabbitMQ
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string HostName { get; set; }

        public int Port { get; set; }

        public UserRabbitMQ()
        {
            this.UserName = "guest";
            this.Password = "guest";
            this.HostName = "localhost";
            this.Port = AmqpTcpEndpoint.UseDefaultPort;
        }

        public UserRabbitMQ(string userName, string password, string hostAddress, int port = AmqpTcpEndpoint.UseDefaultPort)
        {
            this.UserName = userName;
            this.Password = password;
            this.HostName = hostAddress;
            this.Port = port;
        }
    }
}
