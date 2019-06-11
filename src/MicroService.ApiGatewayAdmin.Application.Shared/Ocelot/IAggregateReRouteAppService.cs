using MicroService.ApiGateway.Ocelot.Dto;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MicroService.ApiGateway.Ocelot
{
    public interface IAggregateReRouteAppService : IApplicationService
    {
        Task<ListResultDto<AggregateReRouteDto>> GetListAsync();

        Task<PagedResultDto<AggregateReRouteDto>> GetPagedListAsync(PagedResultRequestDto requestDto);
    }
}
