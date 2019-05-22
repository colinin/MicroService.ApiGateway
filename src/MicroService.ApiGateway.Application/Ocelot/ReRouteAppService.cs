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
        public ReRouteAppService(
            IReRouteRepository reRouteRepository)
        {
            _reRouteRepository = reRouteRepository;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ReRouteDto> CreateAsync(ReRouteDto routeDto)
        {
            var reRoute = ObjectMapper.Map<ReRouteDto, ReRoute>(routeDto);

            ApplyReRouteOptions(reRoute, routeDto);

            reRoute = await _reRouteRepository.InsertAsync(reRoute, true);

            return ObjectMapper.Map<ReRoute, ReRouteDto>(reRoute);
        }

        [HttpPost]
        [Route("Update")]
        public async Task<ReRouteDto> UpdateAsync(ReRouteDto routeDto)
        {
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
                routeDto.UpstreamPathTemplate, routeDto.UpstreamHttpMethod.JoinAsString(";"));
            ApplyReRouteOptions(reRoute, routeDto);

            reRoute = await _reRouteRepository.UpdateAsync(reRoute, true);

            return ObjectMapper.Map<ReRoute, ReRouteDto>(reRoute);
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ReRouteDto> GetAsync(int routeId)
        {
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

        protected virtual void ApplyReRouteOptions(ReRoute reRoute, ReRouteDto routeDto)
        {


            reRoute.AuthenticationOptions.SetOptions(routeDto.AuthenticationOptions.AuthenticationProviderKey, routeDto.AuthenticationOptions.AllowedScopes.ToArray());

            reRoute.CacheOptions.SetCacheOption(routeDto.FileCacheOptions.TtlSeconds, routeDto.FileCacheOptions.Region);

            reRoute.HttpHandlerOptions.ApplyAllowAutoRedirect(routeDto.HttpHandlerOptions.AllowAutoRedirect);
            reRoute.HttpHandlerOptions.ApplyCookieContainer(routeDto.HttpHandlerOptions.UseCookieContainer);
            reRoute.HttpHandlerOptions.ApplyHttpProxy(routeDto.HttpHandlerOptions.UseProxy);
            reRoute.HttpHandlerOptions.ApplyHttpTracing(routeDto.HttpHandlerOptions.UseTracing);

            reRoute.LoadBalancerOptions.SetLoadBalancerOptions(routeDto.LoadBalancerOptions.Type, routeDto.LoadBalancerOptions.Key, routeDto.LoadBalancerOptions.Expiry);

            reRoute.QoSOptions.SetQosOption(routeDto.QoSOptions.ExceptionsAllowedBeforeBreaking, routeDto.QoSOptions.DurationOfBreak, routeDto.QoSOptions.TimeoutValue);

            reRoute.RateLimitOptions.ApplyRateLimit(routeDto.RateLimitOptions.EnableRateLimiting);
            reRoute.RateLimitOptions.SetPeriodTimespan(routeDto.RateLimitOptions.Period, routeDto.RateLimitOptions.PeriodTimespan, routeDto.RateLimitOptions.Limit);
            reRoute.RateLimitOptions.AddClientWhileList(routeDto.RateLimitOptions.ClientWhitelist.ToArray());

            reRoute.SecurityOptions.AddAllowIpList(routeDto.SecurityOptions.IPAllowedList.ToArray());
            reRoute.SecurityOptions.AddBlockIpList(routeDto.SecurityOptions.IPBlockedList.ToArray());

            if(routeDto.DownstreamHeaderTransform != null)
            {
                foreach(var kvalue in routeDto.DownstreamHeaderTransform)
                {
                    var headers = new Headers(reRoute.ReRouteId);
                    headers.SetHeader(kvalue.Key, kvalue.Value);
                    reRoute.AddDownStreamHeader(headers);
                }
            }

            if (routeDto.DownstreamHostAndPorts != null)
            {
                foreach (var hostAndPortDto in routeDto.DownstreamHostAndPorts)
                {
                    var hostAndPort = new HostAndPort(reRoute.ReRouteId);
                    hostAndPort.SetHostAndPort(hostAndPortDto.Host, hostAndPortDto.Port);
                    reRoute.AddDownStreamHostAndPort(hostAndPort);
                }
            }

            if (routeDto.AddClaimsToRequest != null)
            {
                foreach (var kvalue in routeDto.AddClaimsToRequest)
                {
                    var headers = new Headers(reRoute.ReRouteId);
                    headers.SetHeader(kvalue.Key, kvalue.Value);
                    reRoute.AddRequestClaim(headers);
                }
            }

            if (routeDto.AddHeadersToRequest != null)
            {
                foreach (var kvalue in routeDto.AddHeadersToRequest)
                {
                    var headers = new Headers(reRoute.ReRouteId);
                    headers.SetHeader(kvalue.Key, kvalue.Value);
                    reRoute.AddRequestHeader(headers);
                }
            }

            if (routeDto.AddQueriesToRequest != null)
            {
                foreach (var kvalue in routeDto.AddQueriesToRequest)
                {
                    var headers = new Headers(reRoute.ReRouteId);
                    headers.SetHeader(kvalue.Key, kvalue.Value);
                    reRoute.AddRequestQueries(headers);
                }
            }

            if (routeDto.RouteClaimsRequirement != null)
            {
                foreach (var kvalue in routeDto.RouteClaimsRequirement)
                {
                    var headers = new Headers(reRoute.ReRouteId);
                    headers.SetHeader(kvalue.Key, kvalue.Value);
                    reRoute.AddRequirementCalim(headers);
                }
            }

            if (routeDto.UpstreamHeaderTransform != null)
            {
                foreach (var kvalue in routeDto.UpstreamHeaderTransform)
                {
                    var headers = new Headers(reRoute.ReRouteId);
                    headers.SetHeader(kvalue.Key, kvalue.Value);
                    reRoute.AddUpStreamHeader(headers);
                }
            }
        }
    }
}
