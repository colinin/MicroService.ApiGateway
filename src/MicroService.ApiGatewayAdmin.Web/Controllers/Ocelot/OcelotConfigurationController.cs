using MicroService.ApiGateway.Authentication;
using MicroService.ApiGateway.Ocelot;
using MicroService.ApiGateway.Ocelot.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MicroService.ApiGateway.Controllers.OcelotView
{
    [Authorize(Policy = AuthenticationConsts.AdministrationPolicy)]
    [Route("[controller]")]
    public class OcelotConfigurationController : OcelotControllerBase
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
            return View(model);
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
            return await Task.FromResult(View());
        }
        
        [HttpGet]
        [Route("ReRoute")]
        public async Task<IActionResult> ReRoute(long routeId)
        {
            if(routeId == 0)
            {
                return await Task.FromResult(View(new ReRouteDto()));
            }

            var reRouteDto = await _reRouteAppService.GetAsync(routeId);

            return await Task.FromResult(View(reRouteDto));
        }

        [HttpPost]
        [Route("ReRoute")]
        public async Task<IActionResult> ReRoute(ReRouteDto routeDto)
        {
            ReRouteDto reRouteDto;

            if (routeDto.ReRouteId == 0)
            {
                reRouteDto = await _reRouteAppService.CreateAsync(routeDto);
            }
            else
            {
                reRouteDto = await _reRouteAppService.UpdateAsync(routeDto);
            }

            return RedirectToAction("ReRoute", "OcelotConfiguration", new { routeId = reRouteDto.ReRouteId });
        }

        [HttpGet]
        [Route("Source")]
        public async Task<IActionResult> Source()
        {
            return View(null);
        }
    }
}
