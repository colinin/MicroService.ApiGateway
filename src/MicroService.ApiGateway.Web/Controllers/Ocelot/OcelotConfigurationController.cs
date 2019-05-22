using MicroService.ApiGateway.Ocelot;
using MicroService.ApiGateway.Ocelot.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace MicroService.ApiGateway.Controllers.OcelotView
{
    [Route("Ocelot/Configuration")]
    public class OcelotConfigurationController : AbpController
    {
        private readonly IGlobalConfigurationAppService _globalConfigurationAppService;
        private readonly IReRouteAppService _reRouteAppService;

        public OcelotConfigurationController(
            IGlobalConfigurationAppService globalConfigurationAppService,
            IReRouteAppService reRouteAppService)
        {
            _globalConfigurationAppService = globalConfigurationAppService;
            _reRouteAppService = reRouteAppService;
        }
        [HttpGet]
        [Route("Global")]
        public async Task<IActionResult> Global()
        {
            var model = await _globalConfigurationAppService.GetAsync();
            model = model ?? new GlobalConfigurationDto();
            return View("/Views/OcelotConfiguration/Global.cshtml", model);
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

        [HttpGet]
        [Route("ReRoutes")]
        public async Task<IActionResult> ReRoutes()
        {
            return await Task.FromResult(View("/Views/OcelotConfiguration/ReRoutes.cshtml"));
        }

        [HttpGet]
        [Route("ReRoute")]
        public async Task<IActionResult> ReRoute()
        {
            return await Task.FromResult(View("/Views/OcelotConfiguration/ReRoute.cshtml", new ReRouteDto()));
        }

        [HttpGet]
        [Route("ReRouteById")]
        public async Task<IActionResult> ReRoute(int reRouteId)
        {
            var reRouteDto = await _reRouteAppService.GetAsync(reRouteId);

            return await Task.FromResult(View("/Views/OcelotConfiguration/ReRoute.cshtml", reRouteDto));
        }

        [HttpGet]
        [Route("ReRouteByName")]
        public async Task<IActionResult> ReRoute(string routeName)
        {
            var reRouteDto = await _reRouteAppService.GetByRouteNameAsync(routeName);

            return await Task.FromResult(View("/Views/OcelotConfiguration/ReRoute.cshtml", reRouteDto));
        }

        [HttpPost]
        [Route("ReRoute")]
        public async Task<IActionResult> ReRoute(ReRouteDto routeDto)
        {
            ReRouteDto reRouteDto;

            if (routeDto.ReRouteId != 0)
            {
                reRouteDto = await _reRouteAppService.CreateAsync(routeDto);
            }
            else
            {
                reRouteDto = await _reRouteAppService.UpdateAsync(routeDto);
            }

            return RedirectToAction(nameof(ReRoute), reRouteDto.ReRouteId);
        }
    }
}
