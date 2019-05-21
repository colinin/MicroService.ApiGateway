using MicroService.ApiGateway.Entites.Ocelot;
using MicroService.ApiGateway.Ocelot.Dto;
using MicroService.ApiGateway.Repositories;
using MicroService.ApiGateway.Snowflake;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace MicroService.ApiGateway.Ocelot
{
    [Route("GlobalConfiguration")]
    public class GlobalConfigurationAppService : ApplicationService, IGlobalConfigurationAppService
    {
        private readonly IGlobalConfigRepository _globalConfigRepository;
        private readonly ISnowflakeIdGenerator _snowflakeIdGenerator;
        public GlobalConfigurationAppService(
            IGlobalConfigRepository globalConfigRepository,
            ISnowflakeIdGenerator snowflakeIdGenerator
            )
        {
            _globalConfigRepository = globalConfigRepository;
            _snowflakeIdGenerator = snowflakeIdGenerator;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<GlobalConfigurationDto> GetAsync()
        {
            var globalConfig =  await _globalConfigRepository.GetOneAsync();

            return ObjectMapper.Map<GlobalConfiguration, GlobalConfigurationDto>(globalConfig);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<GlobalConfigurationDto> CreateAsync(GlobalConfigurationDto configurationDto)
        {
            var globalConfiguration = new GlobalConfiguration(_snowflakeIdGenerator.NextId(), configurationDto.BaseUrl);
            globalConfiguration.RequestIdKey = configurationDto.RequestIdKey;
            globalConfiguration.DownstreamScheme = configurationDto.DownstreamScheme;

            ApplyGlobalConfigurationOptions(globalConfiguration, configurationDto);

            globalConfiguration = await _globalConfigRepository.InsertAsync(globalConfiguration, true);

            return ObjectMapper.Map<GlobalConfiguration, GlobalConfigurationDto>(globalConfiguration);
        }

        [HttpPost]
        [Route("Update")]
        public async Task<GlobalConfigurationDto> UpdateAsync(GlobalConfigurationDto configurationDto)
        {
            var globalConfiguration = await _globalConfigRepository.GetByItemIdAsync(configurationDto.ItemId);

            globalConfiguration.BaseUrl = configurationDto.BaseUrl;
            globalConfiguration.RequestIdKey = configurationDto.RequestIdKey;
            globalConfiguration.DownstreamScheme = configurationDto.DownstreamScheme;

            ApplyGlobalConfigurationOptions(globalConfiguration, configurationDto);

            globalConfiguration = await _globalConfigRepository.UpdateAsync(globalConfiguration, true);

            return ObjectMapper.Map<GlobalConfiguration, GlobalConfigurationDto>(globalConfiguration);
        }


        private void ApplyGlobalConfigurationOptions(GlobalConfiguration globalConfiguration, GlobalConfigurationDto configurationDto)
        {

            if (!string.IsNullOrWhiteSpace(configurationDto.ServiceDiscoveryProvider.Host)){
                globalConfiguration.ServiceDiscoveryProvider.BindServiceRegister(configurationDto.ServiceDiscoveryProvider.Host, configurationDto.ServiceDiscoveryProvider.Port);
            }

            globalConfiguration.HttpHandlerOptions.ApplyAllowAutoRedirect(configurationDto.HttpHandlerOptions.AllowAutoRedirect);
            globalConfiguration.HttpHandlerOptions.ApplyCookieContainer(configurationDto.HttpHandlerOptions.UseCookieContainer);
            globalConfiguration.HttpHandlerOptions.ApplyHttpProxy(configurationDto.HttpHandlerOptions.UseProxy);
            globalConfiguration.HttpHandlerOptions.ApplyHttpTracing(configurationDto.HttpHandlerOptions.UseTracing);
            
            globalConfiguration.QoSOptions.SetQosOption(configurationDto.QoSOptions.ExceptionsAllowedBeforeBreaking, configurationDto.QoSOptions.DurationOfBreak,
                configurationDto.QoSOptions.TimeoutValue);

            if (!configurationDto.RateLimitOptions.DisableRateLimitHeaders)
            {
                globalConfiguration.RateLimitOptions.SetRateLimitOptions(configurationDto.RateLimitOptions.ClientIdHeader, configurationDto.RateLimitOptions.QuotaExceededMessage,
                    configurationDto.RateLimitOptions.HttpStatusCode);
            }
            
            globalConfiguration.LoadBalancerOptions.SetLoadBalancerOptions(configurationDto.LoadBalancerOptions.Type, configurationDto.LoadBalancerOptions.Key,
                configurationDto.LoadBalancerOptions.Expiry);
        }
    }
}
