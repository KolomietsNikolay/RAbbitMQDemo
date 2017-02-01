using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQManager
{
    public interface IBaseRabbitMQ
    {
        void InitConnection(UserRabbitMQ user);
    }
}
