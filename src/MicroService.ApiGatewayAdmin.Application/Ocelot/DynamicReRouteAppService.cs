using MicroService.ApiGateway.Entites.Ocelot;
using MicroService.ApiGateway.Ocelot.Dto;
using MicroService.ApiGateway.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace MicroService.ApiGateway.Ocelot
{
    [Route("DynamicReRoute")]
    public class DynamicReRouteAppService : ApiGatewayApplicationServiceBase, IDynamicReRouteAppService
    {
        private readonly IDynamicReRouteRepository _dynamicReRouteRepository;
        public DynamicReRouteAppService(IDynamicReRouteRepository dynamicReRouteRepository)
        {
            _dynamicReRouteRepository = dynamicReRouteRepository;
        }

        [HttpGet]
        [Route("GetList")]
        public async Task<ListResultDto<DynamicReRouteDto>> GetListAsync()
        {
            var dynamicReRoutes = await _dynamicReRouteRepository.GetListAsync();

            return new ListResultDto<DynamicReRouteDto>(ObjectMapper.Map<List<DynamicReRoute>, List<DynamicReRouteDto>>(dynamicReRoutes));
        }
    }
}
