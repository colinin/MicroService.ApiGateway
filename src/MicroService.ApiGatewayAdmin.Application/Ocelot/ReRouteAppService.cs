using MicroService.ApiGateway.Entites.Ocelot;
using MicroService.ApiGateway.Ocelot.Dto;
using MicroService.ApiGateway.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using DotNetCore.CAP;
using MicroService.ApiGatewayAdmin.Ocelot.Event;

namespace MicroService.ApiGateway.Ocelot
{
    [Route("ReRoute")]
    public class ReRouteAppService : ApiGatewayApplicationServiceBase, IReRouteAppService
    {
        private readonly IReRouteRepository _reRouteRepository;
        private readonly ICapPublisher _eventPublisher;

        public ReRouteAppService(
            IReRouteRepository reRouteRepository,
            ICapPublisher eventPublisher)
        {
            _reRouteRepository = reRouteRepository;
            _eventPublisher = eventPublisher;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ReRouteDto> CreateAsync(ReRouteDto routeDto)
        {
            await CheckPolicyAsync();

            var reRoute = ObjectMapper.Map<ReRouteDto, ReRoute>(routeDto);

            ApplyReRouteOptions(reRoute, routeDto);

            reRoute = await _reRouteRepository.InsertAsync(reRoute, true);

            var reRouteDto = ObjectMapper.Map<ReRoute, ReRouteDto>(reRoute);

            await _eventPublisher.PublishAsync(ApiGatewayDomainConsts.Events_OcelotConfigChanged, new OcelotConfigChangeCommand("ReRoute", "Create"));

            return reRouteDto;
        }

        [HttpPost]
        [Route("Update")]
        public async Task<ReRouteDto> UpdateAsync(ReRouteDto routeDto)
        {
            await CheckPolicyAsync();

            var reRoute = await _reRouteRepository.GetByReRouteIdAsync(routeDto.ReRouteId);

            reRoute.DangerousAcceptAnyServerCertificateValidator = routeDto.DangerousAcceptAnyServerCertificateValidator;
            reRoute.DownstreamScheme = routeDto.DownstreamScheme;
            reRoute.Key = routeDto.Key;
            reRoute.Priority = routeDto.Priority;
            reRoute.RequestIdKey = routeDto.RequestIdKey;
            reRoute.ReRouteIsCaseSensitive = routeDto.ReRouteIsCaseSensitive;
            reRoute.ServiceName = routeDto.ServiceName;
            reRoute.Timeout = routeDto.Timeout;
            reRoute.UpstreamHost = routeDto.UpstreamHost;

            reRoute.ModifyRouteInfo(routeDto.ReRouteName, routeDto.DownstreamPathTemplate, 
                routeDto.UpstreamPathTemplate, routeDto.UpstreamHttpMethod, routeDto.DownstreamHostAndPorts);
            ApplyReRouteOptions(reRoute, routeDto);

            reRoute = await _reRouteRepository.UpdateAsync(reRoute, true);

            var reRouteDto = ObjectMapper.Map<ReRoute, ReRouteDto>(reRoute);

            await _eventPublisher.PublishAsync(ApiGatewayDomainConsts.Events_OcelotConfigChanged, new OcelotConfigChangeCommand("ReRoute", "Modify"));

            return reRouteDto;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ReRouteDto> GetAsync(long routeId)
        {
            if (routeId == 0)
            {
                return new ReRouteDto();
            }

            var reRoute = await _reRouteRepository.GetByReRouteIdAsync(routeId);

            return ObjectMapper.Map<ReRoute, ReRouteDto>(reRoute);
        }

        [HttpGet]
        [Route("GetByRouteName")]
        public async Task<ReRouteDto> GetByRouteNameAsync(string routeName)
        {
            var reRoute = await _reRouteRepository.GetByNameAsync(routeName);

            return ObjectMapper.Map<ReRoute, ReRouteDto>(reRoute);
        }

        [HttpGet]
        [Route("GetList")]
        public async Task<ListResultDto<ReRouteDto>> GetListAsync()
        {
            var reroutes = await _reRouteRepository.GetListAsync(true);

            return new ListResultDto<ReRouteDto>(ObjectMapper.Map<List<ReRoute>, List<ReRouteDto>>(reroutes));
        }

        [HttpGet]
        [Route("GetPagedList")]
        public async Task<PagedResultDto<ReRouteDto>> GetPagedListAsync(PagedResultRequestDto requestDto)
        {
            var reroutesTuple = await _reRouteRepository.GetPagedListAsync(requestDto.SkipCount, requestDto.MaxResultCount);

            return new PagedResultDto<ReRouteDto>(reroutesTuple.total, ObjectMapper.Map<List<ReRoute>, List<ReRouteDto>>(reroutesTuple.routes));
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task DeleteAsync(long routeId)
        {
            await CheckPolicyAsync();

            await _reRouteRepository.DeleteAsync(x => x.ReRouteId.Equals(routeId));

            await _eventPublisher.PublishAsync(ApiGatewayDomainConsts.Events_OcelotConfigChanged, new OcelotConfigChangeCommand("ReRoute", "Delete"));
        }

        [HttpDelete]
        [Route("Remove")]
        public async Task RemoveAsync()
        {
            await CheckPolicyAsync();

            await _reRouteRepository.RemoveAsync();

            await _eventPublisher.PublishAsync(ApiGatewayDomainConsts.Events_OcelotConfigChanged, new OcelotConfigChangeCommand("ReRoute", "Clean"));
        }

        protected virtual void ApplyReRouteOptions(ReRoute reRoute, ReRouteDto routeDto)
        {
            reRoute.SetDownstreamHeader(routeDto.DownstreamHeaderTransform);
            reRoute.SetQueriesParamter(routeDto.AddQueriesToRequest);
            reRoute.SetRequestClaims(routeDto.AddClaimsToRequest);
            reRoute.SetRequestHeader(routeDto.AddHeadersToRequest);
            reRoute.SetRouteClaims(routeDto.RouteClaimsRequirement);
            reRoute.SetUpstreamHeader(routeDto.UpstreamHeaderTransform);

            reRoute.AuthenticationOptions.ApplyAuthOptions(routeDto.AuthenticationOptions.AuthenticationProviderKey, routeDto.AuthenticationOptions.AllowedScopes);

            reRoute.CacheOptions.ApplyCacheOption(routeDto.FileCacheOptions.TtlSeconds, routeDto.FileCacheOptions.Region);

            reRoute.HttpHandlerOptions.ApplyAllowAutoRedirect(routeDto.HttpHandlerOptions.AllowAutoRedirect);
            reRoute.HttpHandlerOptions.ApplyCookieContainer(routeDto.HttpHandlerOptions.UseCookieContainer);
            reRoute.HttpHandlerOptions.ApplyHttpProxy(routeDto.HttpHandlerOptions.UseProxy);
            reRoute.HttpHandlerOptions.ApplyHttpTracing(routeDto.HttpHandlerOptions.UseTracing);

            reRoute.LoadBalancerOptions.ApplyLoadBalancerOptions(routeDto.LoadBalancerOptions.Type, routeDto.LoadBalancerOptions.Key, routeDto.LoadBalancerOptions.Expiry);

            reRoute.QoSOptions.ApplyQosOptions(routeDto.QoSOptions.ExceptionsAllowedBeforeBreaking, routeDto.QoSOptions.DurationOfBreak, routeDto.QoSOptions.TimeoutValue);

            reRoute.RateLimitOptions.ApplyRateLimit(routeDto.RateLimitOptions.EnableRateLimiting);
            reRoute.RateLimitOptions.SetPeriodTimespan(routeDto.RateLimitOptions.Period, routeDto.RateLimitOptions.PeriodTimespan, routeDto.RateLimitOptions.Limit);
            reRoute.RateLimitOptions.SetClientWhileList(routeDto.RateLimitOptions.ClientWhitelist);

            reRoute.SecurityOptions.SetAllowIpList(routeDto.SecurityOptions.IPAllowedList);
            reRoute.SecurityOptions.SetBlockIpList(routeDto.SecurityOptions.IPBlockedList);
        }
    }
}
