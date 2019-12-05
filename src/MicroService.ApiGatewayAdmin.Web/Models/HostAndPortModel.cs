using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroService.ApiGateway.Ocelot.Dto
{
    public class HostAndPortModel
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public HostAndPortModel()
        {
            Port = 80;
        }
    }
}
