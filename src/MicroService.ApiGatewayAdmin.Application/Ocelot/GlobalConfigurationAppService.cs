using DotNetCore.CAP;
using MicroService.ApiGateway.Entites.Ocelot;
using MicroService.ApiGateway.Ocelot.Dto;
using MicroService.ApiGateway.Repositories;
using MicroService.ApiGateway.Snowflake;
using MicroService.ApiGatewayAdmin.Ocelot.Event;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MicroService.ApiGateway.Ocelot
{
    [Route("GlobalConfiguration")]
    public class GlobalConfigurationAppService : ApiGatewayApplicationServiceBase, IGlobalConfigurationAppService
    {
        private readonly IGlobalConfigRepository _globalConfigRepository;
        private readonly ISnowflakeIdGenerator _snowflakeIdGenerator;
        private readonly ICapPublisher _eventPublisher;
        public GlobalConfigurationAppService(
            IGlobalConfigRepository globalConfigRepository,
            ISnowflakeIdGenerator snowflakeIdGenerator,
            ICapPublisher eventPublisher
            )
        {
            _globalConfigRepository = globalConfigRepository;
            _snowflakeIdGenerator = snowflakeIdGenerator;
            _eventPublisher = eventPublisher;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<GlobalConfigurationDto> GetAsync()
        {
            var globalConfig =  await _globalConfigRepository.GetOneAsync();

            var globalConfigDto = ObjectMapper.Map<GlobalConfiguration, GlobalConfigurationDto>(globalConfig);

            return globalConfigDto;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<GlobalConfigurationDto> CreateAsync(GlobalConfigurationDto configurationDto)
        {
            await CheckPolicyAsync();

            var globalConfiguration = new GlobalConfiguration(_snowflakeIdGenerator.NextId(), configurationDto.BaseUrl);
            globalConfiguration.RequestIdKey = configurationDto.RequestIdKey;
            globalConfiguration.DownstreamScheme = configurationDto.DownstreamScheme;

            ApplyGlobalConfigurationOptions(globalConfiguration, configurationDto);

            globalConfiguration = await _globalConfigRepository.InsertAsync(globalConfiguration, true);

            await _eventPublisher.PublishAsync(ApiGatewayDomainConsts.Events_OcelotConfigChanged, new OcelotConfigChangeCommand("Global", "Create"));

            return ObjectMapper.Map<GlobalConfiguration, GlobalConfigurationDto>(globalConfiguration);
        }

        [HttpPost]
        [Route("Update")]
        public async Task<GlobalConfigurationDto> UpdateAsync(GlobalConfigurationDto configurationDto)
        {
            await CheckPolicyAsync();

            var globalConfiguration = await _globalConfigRepository.GetByItemIdAsync(configurationDto.ItemId);

            globalConfiguration.BaseUrl = configurationDto.BaseUrl;
            globalConfiguration.RequestIdKey = configurationDto.RequestIdKey;
            globalConfiguration.DownstreamScheme = configurationDto.DownstreamScheme;

            ApplyGlobalConfigurationOptions(globalConfiguration, configurationDto);

            globalConfiguration = await _globalConfigRepository.UpdateAsync(globalConfiguration, true);

            await _eventPublisher.PublishAsync(ApiGatewayDomainConsts.Events_OcelotConfigChanged, new OcelotConfigChangeCommand("Global", "Modify"));

            return ObjectMapper.Map<GlobalConfiguration, GlobalConfigurationDto>(globalConfiguration);
        }


        private void ApplyGlobalConfigurationOptions(GlobalConfiguration globalConfiguration, GlobalConfigurationDto configurationDto)
        {
            globalConfiguration.ServiceDiscoveryProvider.Type = configurationDto.ServiceDiscoveryProvider.Type;
            globalConfiguration.ServiceDiscoveryProvider
                .BindServiceRegister(configurationDto.ServiceDiscoveryProvider.Host, configurationDto.ServiceDiscoveryProvider.Port);

            globalConfiguration.HttpHandlerOptions.ApplyAllowAutoRedirect(configurationDto.HttpHandlerOptions.AllowAutoRedirect);
            globalConfiguration.HttpHandlerOptions.ApplyCookieContainer(configurationDto.HttpHandlerOptions.UseCookieContainer);
            globalConfiguration.HttpHandlerOptions.ApplyHttpProxy(configurationDto.HttpHandlerOptions.UseProxy);
            globalConfiguration.HttpHandlerOptions.ApplyHttpTracing(configurationDto.HttpHandlerOptions.UseTracing);
            
            globalConfiguration.QoSOptions.ApplyQosOptions(configurationDto.QoSOptions.ExceptionsAllowedBeforeBreaking, configurationDto.QoSOptions.DurationOfBreak,
                configurationDto.QoSOptions.TimeoutValue);

            if (!configurationDto.RateLimitOptions.DisableRateLimitHeaders)
            {
                globalConfiguration.RateLimitOptions.ApplyRateLimitOptions(configurationDto.RateLimitOptions.ClientIdHeader, configurationDto.RateLimitOptions.QuotaExceededMessage,
                    configurationDto.RateLimitOptions.HttpStatusCode);
            }
            
            globalConfiguration.LoadBalancerOptions.ApplyLoadBalancerOptions(configurationDto.LoadBalancerOptions.Type, configurationDto.LoadBalancerOptions.Key,
                configurationDto.LoadBalancerOptions.Expiry);
        }
    }
}
