using MicroService.ApiGatewayAdmin.Ocelot.Event;
using System.Threading.Tasks;

namespace MicroService.ApiGateway.Event
{
    public interface IOcelotConfigurationChangedEvent
    {
        Task OnOcelotConfigurationChanged(OcelotConfigChangeCommand changeCommand);
    }
}
