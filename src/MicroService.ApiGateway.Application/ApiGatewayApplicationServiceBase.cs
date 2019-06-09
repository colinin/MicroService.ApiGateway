using MicroService.ApiGateway.Authentication;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace MicroService.ApiGateway
{
    public class ApiGatewayApplicationServiceBase : ApplicationService
    {
        protected virtual string OcelotManagerPolicy => AuthenticationConsts.AdministrationPolicy;

        protected ApiGatewayApplicationServiceBase()
        {

        }

        protected virtual async Task CheckPolicyAsync()
        {
            await CheckPolicyAsync(OcelotManagerPolicy);
        }
    }
}
