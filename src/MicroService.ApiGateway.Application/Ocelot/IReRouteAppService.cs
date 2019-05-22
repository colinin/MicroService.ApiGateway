using MicroService.ApiGateway.Ocelot.Dto;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MicroService.ApiGateway.Ocelot
{
    public interface IReRouteAppService : IApplicationService
    {
        Task<ListResultDto<ReRouteDto>> GetListAsync();

        Task<PagedResultDto<ReRouteDto>> GetPagedListAsync(PagedResultRequestDto requestDto);

        Task<ReRouteDto> GetByRouteNameAsync(string routeName);

        Task<ReRouteDto> GetAsync(int routeId);

        Task<ReRouteDto> CreateAsync(ReRouteDto routeDto);

        Task<ReRouteDto> UpdateAsync(ReRouteDto routeDto);
    }
}
