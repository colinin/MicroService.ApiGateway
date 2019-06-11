using System;
using System.Threading.Tasks;

namespace MicroService.ApiGateway.Event
{
    public interface IOcelotConfigurationChangedEvent
    {
        Task OnOcelotConfigurationChanged(DateTime changedTime);
    }
}
