using MicroService.ApiGateway.Ocelot;
using MicroService.ApiGateway.Ocelot.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace MicroService.ApiGateway.Controllers.OcelotView
{
    [Route("Ocelot/Configuration")]
    public class OcelotGlobalCongifurationController : AbpController
    {
        private readonly IGlobalConfigurationAppService _globalConfigurationAppService;
        public OcelotGlobalCongifurationController(
            IGlobalConfigurationAppService globalConfigurationAppService)
        {
            _globalConfigurationAppService = globalConfigurationAppService;
        }
        [HttpGet]
        [Route("Global")]
        public async Task<IActionResult> Global()
        {
            var model = await _globalConfigurationAppService.GetAsync();
            model = model ?? new GlobalConfigurationDto();
            return View("/Views/Ocelot/Global.cshtml", model);
        }

        [HttpPost]
        [Route("Global")]
        public async Task<IActionResult> Global(GlobalConfigurationDto configurationDto)
        {
            if (configurationDto.ItemId == 0)
            {
                await _globalConfigurationAppService.CreateAsync(configurationDto);
            }
            else
            {
                await _globalConfigurationAppService.UpdateAsync(configurationDto);
            }
            return RedirectToAction(nameof(Global));
        }
    }
}
