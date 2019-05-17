using MicroService.ApiGateway.Entites.Ocelot;
using MicroService.ApiGateway.Ocelot.Dto;
using MicroService.ApiGateway.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MicroService.ApiGateway.Ocelot
{
    [Route("ReRoute")]
    public class ReRouteAppService : ApplicationService, IReRouteAppService
    {
        private readonly IReRouteRepository _reRouteRepository;
        public ReRouteAppService(IReRouteRepository reRouteRepository)
        {
            _reRouteRepository = reRouteRepository;
        }

        [HttpGet]
        [Route("Get/routeId")]
        public async Task<ReRouteDto> GetAsync(int routeId)
        {
            var reRoute = await _reRouteRepository.GetByReRouteIdAsync(routeId);

            return ObjectMapper.Map<ReRoute, ReRouteDto>(reRoute);
        }

        [HttpGet]
        [Route("GetByRouteName/routeName")]
        public async Task<ReRouteDto> GetByRouteNameAsync(string routeName)
        {
            var reRoute = await _reRouteRepository.GetByNameAsync(routeName);

            return ObjectMapper.Map<ReRoute, ReRouteDto>(reRoute);
        }

        [HttpGet]
        [Route("GetList")]
        public async Task<ListResultDto<ReRouteDto>> GetListAsync()
        {
            var reroutes = await _reRouteRepository.GetListAsync();

            return new ListResultDto<ReRouteDto>(ObjectMapper.Map<List<ReRoute>, List<ReRouteDto>>(reroutes));
        }

        [HttpGet]
        [Route("GetPagedList")]
        public async Task<PagedResultDto<ReRouteDto>> GetPagedListAsync(PagedResultRequestDto requestDto)
        {
            var reroutesTuple = await _reRouteRepository.GetPagedListAsync(requestDto.SkipCount, requestDto.MaxResultCount);

            return new PagedResultDto<ReRouteDto>(reroutesTuple.total, ObjectMapper.Map<List<ReRoute>, List<ReRouteDto>>(reroutesTuple.routes));
        }
    }
}
