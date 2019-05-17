using MicroService.ApiGateway.Entites.Ocelot;
using MicroService.ApiGateway.Ocelot.Dto;
using MicroService.ApiGateway.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace MicroService.ApiGateway.Ocelot
{
    [Route("GlobalConfiguration")]
    public class GlobalConfigurationAppService : ApplicationService, IGlobalConfigurationAppService
    {
        private readonly IGlobalConfigRepository _globalConfigRepository;
        public GlobalConfigurationAppService(IGlobalConfigRepository globalConfigRepository)
        {
            _globalConfigRepository = globalConfigRepository;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<GlobalConfigurationDto> GetAsync()
        {
            var globalConfig =  await _globalConfigRepository.GetOneAsync();

            return ObjectMapper.Map<GlobalConfiguration, GlobalConfigurationDto>(globalConfig);
        }
    }
}
