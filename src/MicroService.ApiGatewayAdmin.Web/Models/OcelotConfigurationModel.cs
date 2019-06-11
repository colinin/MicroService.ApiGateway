using MicroService.ApiGateway.Ocelot.Dto;
using System;
using System.Collections.Generic;

namespace MicroService.ApiGateway.Web.Models
{
    [Serializable]
    public class OcelotConfigurationModel
    {
        public List<ReRouteModel> ReRoutes { get; set; }
        public List<DynamicReRouteModel> DynamicReRoutes { get; set; }
        public List<AggregateReRouteModel> Aggregates { get; set; }
        public GlobalConfigurationModel GlobalConfiguration { get; set; }

        public OcelotConfigurationModel()
        {
            ReRoutes = new List<ReRouteModel>();
            DynamicReRoutes = new List<DynamicReRouteModel>();
            Aggregates = new List<AggregateReRouteModel>();
            GlobalConfiguration = new GlobalConfigurationModel();
        }
    }
}
