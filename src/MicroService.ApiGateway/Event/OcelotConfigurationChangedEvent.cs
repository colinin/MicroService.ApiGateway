using DotNetCore.CAP;
using MicroService.ApiGatewayAdmin.Ocelot.Event;
using Microsoft.Extensions.Logging;
using Ocelot.Configuration.Creator;
using Ocelot.Configuration.Repository;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace MicroService.ApiGateway.Event
{
    public class OcelotConfigurationChangedEvent : IOcelotConfigurationChangedEvent, ITransientDependency, ICapSubscribe
    {
        private readonly ILogger<OcelotConfigurationChangedEvent> _logger;

        private readonly IFileConfigurationRepository _fileConfigRepo;
        private readonly IInternalConfigurationRepository _internalConfigRepo;
        private readonly IInternalConfigurationCreator _internalConfigCreator;
        public OcelotConfigurationChangedEvent(
            IFileConfigurationRepository fileConfigRepo,
            IInternalConfigurationRepository internalConfigRepo,
            IInternalConfigurationCreator internalConfigCreator,
            ILogger<OcelotConfigurationChangedEvent> logger)
        {
            _fileConfigRepo = fileConfigRepo;
            _internalConfigRepo = internalConfigRepo;
            _internalConfigCreator = internalConfigCreator;
            _logger = logger;
        }

        [CapSubscribe(ApiGatewayDomainConsts.Events_OcelotConfigChanged)]
        public async Task OnOcelotConfigurationChanged(OcelotConfigChangeCommand changeCommand)
        {
            var fileConfig = await _fileConfigRepo.Get();

            if (fileConfig.IsError)
            {
                _logger.LogWarning($"error geting file config, errors are {string.Join(",", fileConfig.Errors.Select(x => x.Message))}");
                return;
            }
            else
            {
                var config = await _internalConfigCreator.Create(fileConfig.Data);
                if (!config.IsError)
                {
                    _internalConfigRepo.AddOrReplace(config.Data);
                }
            }
            _logger.LogInformation("ocelot configuration changed on {0}", changeCommand.DateTime);
        }
    }
}
