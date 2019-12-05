using System;

namespace MicroService.ApiGatewayAdmin.Ocelot.Event
{
    public class OcelotConfigChangeCommand
    {
        public DateTime DateTime { get; set; }
        public string Method { get; set; }
        public string Object { get; set; }
        protected OcelotConfigChangeCommand()
        {

        }

        public OcelotConfigChangeCommand(string @object, string @method)
        {
            DateTime = DateTime.Now;
            Object = @object;
            Method = @method;
        }
    }
}
