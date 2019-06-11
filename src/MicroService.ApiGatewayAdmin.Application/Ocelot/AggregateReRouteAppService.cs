using DotNetCore.CAP;
using MicroService.ApiGateway.Entites.Ocelot;
using MicroService.ApiGateway.Ocelot.Dto;
using MicroService.ApiGateway.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace MicroService.ApiGateway.Ocelot
{
    [Route("AggregateReRoute")]
    public class AggregateReRouteAppService : ApiGatewayApplicationServiceBase, IAggregateReRouteAppService
    {
        private readonly IAggregateReRouteRepository _aggregateReRouteRepository;
        private readonly ICapPublisher _eventPublisher;

        public AggregateReRouteAppService(IAggregateReRouteRepository aggregateReRouteRepository,
            ICapPublisher capPublisher)
        {
            _aggregateReRouteRepository = aggregateReRouteRepository;
            _eventPublisher = capPublisher;
        }

        [HttpGet]
        [Route("GetList")]
        public async Task<ListResultDto<AggregateReRouteDto>> GetListAsync()
        {
            var reroutes = await _aggregateReRouteRepository.GetListAsync(true);

            return new ListResultDto<AggregateReRouteDto>(ObjectMapper.Map<List<AggregateReRoute>, List<AggregateReRouteDto>>(reroutes));
        }

        [HttpGet]
        [Route("GetPagedList")]
        public async Task<PagedResultDto<AggregateReRouteDto>> GetPagedListAsync(PagedResultRequestDto requestDto)
        {
            var reroutesTuple = await _aggregateReRouteRepository.GetPagedListAsync(requestDto.SkipCount, requestDto.MaxResultCount);

            return new PagedResultDto<AggregateReRouteDto>(reroutesTuple.total,
                ObjectMapper.Map<List<AggregateReRoute>, List<AggregateReRouteDto>>(reroutesTuple.routes));
        }
    }
}
