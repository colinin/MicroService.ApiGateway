using MicroService.ApiGateway.Authentication;
using MicroService.ApiGateway.Ocelot;
using MicroService.ApiGateway.Ocelot.Dto;
using MicroService.ApiGateway.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroService.ApiGateway.Controllers.OcelotView
{
    [Authorize(Policy = AuthenticationConsts.AdministrationPolicy)]
    [Route("[controller]")]
    public class OcelotConfigurationController : OcelotControllerBase
    {
        private readonly IGlobalConfigurationAppService _globalConfigurationAppService;
        private readonly IReRouteAppService _reRouteAppService;
        private readonly IDynamicReRouteAppService _dynamicReRouteAppService;
        private readonly IAggregateReRouteAppService _aggregateReRouteAppService;

        public OcelotConfigurationController(
            IGlobalConfigurationAppService globalConfigurationAppService,
            IDynamicReRouteAppService dynamicReRouteAppService,
            IAggregateReRouteAppService aggregateReRouteAppService,
            IReRouteAppService reRouteAppService)
        {
            _globalConfigurationAppService = globalConfigurationAppService;
            _aggregateReRouteAppService = aggregateReRouteAppService;
            _dynamicReRouteAppService = dynamicReRouteAppService;
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
            var globalConfig = await _globalConfigurationAppService.GetAsync();
            var reRouteConfig = await _reRouteAppService.GetListAsync();
            var dynamicConfig = await _dynamicReRouteAppService.GetListAsync();
            var aggregateConfig = await _aggregateReRouteAppService.GetListAsync();

            // 这是个弊端,以后如果Ocelot的配置属性变更
            // Admin程序随之需要变更实体、Dto、Model三个地方
            // 其他解决办法 Emit? 
            // 如果直接引用Ocelot即可解决,但是在Admin中引用它违反了设计结构

            var ocelotConfigurationDto = new OcelotConfigurationModel
            {
                GlobalConfiguration = ObjectMapper.Map<GlobalConfigurationDto, GlobalConfigurationModel>(globalConfig),
                ReRoutes = ObjectMapper.Map<List<ReRouteDto>, List<ReRouteModel>>(reRouteConfig.Items.ToList()),
                DynamicReRoutes = ObjectMapper.Map<List<DynamicReRouteDto>, List<DynamicReRouteModel>>(dynamicConfig.Items.ToList()),
                Aggregates = ObjectMapper.Map<List<AggregateReRouteDto>, List<AggregateReRouteModel>>(aggregateConfig.Items.ToList())
            };

            return View(ocelotConfigurationDto);
        }

    }
}
