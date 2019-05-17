using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace MicroService.ApiGateway.Test
{
    public class TestAppService : ApplicationService, ITestAppService, ITransientDependency
    {
        public async Task<dynamic> Tigger()
        {
            return await Task.FromResult(new { Name = "Good"});
        }
    }
}
