using MicroService.ApiGateway.Ocelot;
using MicroService.ApiGateway.Ocelot.Dto;
using Ocelot.Configuration.File;
using Ocelot.Responses;
using System.Threading.Tasks;
using Volo.Abp.ObjectMapping;

namespace Ocelot.Configuration.Repository
{
    public class ApiHttpClientFileConfigurationRepository : IFileConfigurationRepository
    {
        private readonly IReRouteAppService _reRouteAppService;
        private readonly IGlobalConfigurationAppService _globalConfigurationAppService;
        private readonly IDynamicReRouteAppService _dynamicReRouteAppService;
        private readonly IObjectMapper _objectMapper;
        public ApiHttpClientFileConfigurationRepository(
            IReRouteAppService reRouteAppService,
            IGlobalConfigurationAppService globalConfigurationAppService,
            IDynamicReRouteAppService dynamicReRouteAppService,
            IObjectMapper objectMapper)
        {
            _reRouteAppService = reRouteAppService;
            _globalConfigurationAppService = globalConfigurationAppService;
            _dynamicReRouteAppService = dynamicReRouteAppService;
            _objectMapper = objectMapper;
        }
        public async Task<Response<FileConfiguration>> Get()
        {
            var fileConfiguration = new FileConfiguration();

            var globalConfiguration = await _globalConfigurationAppService.GetAsync();

            fileConfiguration.GlobalConfiguration = _objectMapper.Map<GlobalConfigurationDto, FileGlobalConfiguration>(globalConfiguration);

            var reRouteConfiguration = await _reRouteAppService.GetListAsync();

            if (reRouteConfiguration != null && reRouteConfiguration.Items.Count > 0)
            {
                foreach(var reRouteConfig in reRouteConfiguration.Items)
                {
                    fileConfiguration.ReRoutes.Add(_objectMapper.Map<ReRouteDto, FileReRoute>(reRouteConfig));
                }
            }

            var dynamicReRouteConfiguration = await _dynamicReRouteAppService.GetListAsync();

            if (dynamicReRouteConfiguration != null && dynamicReRouteConfiguration.Items.Count > 0)
            {
                foreach (var dynamicRouteConfig in dynamicReRouteConfiguration.Items)
                {
                    fileConfiguration.DynamicReRoutes.Add(_objectMapper.Map<DynamicReRouteDto, FileDynamicReRoute>(dynamicRouteConfig));
                }
            }

            return new OkResponse<FileConfiguration>(fileConfiguration);
        }

        public async Task<Response> Set(FileConfiguration fileConfiguration)
        {
            // 不实现,从自己的微服务中去实现
            return await Task.FromResult(new OkResponse<FileConfiguration>(fileConfiguration));
        }
    }
}
