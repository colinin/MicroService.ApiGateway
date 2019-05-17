using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace MicroService.ApiGateway.Test
{
    public interface ITestAppService : IApplicationService
    {
        Task<dynamic> Tigger();
    }
}
