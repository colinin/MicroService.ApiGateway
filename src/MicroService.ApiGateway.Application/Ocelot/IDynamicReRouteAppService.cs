using MicroService.ApiGateway.Ocelot.Dto;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MicroService.ApiGateway.Ocelot
{
    public interface IDynamicReRouteAppService : IApplicationService
    {
        Task<ListResultDto<DynamicReRouteDto>> GetListAsync();
    }
}
