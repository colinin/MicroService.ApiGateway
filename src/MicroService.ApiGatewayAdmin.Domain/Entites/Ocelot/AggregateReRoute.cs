using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace MicroService.ApiGateway.Entites.Ocelot
{
    // TODO: 聚合暂时不实现
    public class AggregateReRoute : AggregateRoot<int>
    {
        public virtual long ReRouteId { get; private set; }
        public virtual string ReRouteKeys { get; private set; }
        public virtual List<AggregateReRouteConfig> ReRouteKeysConfig { get; private set; }
        public virtual string UpstreamPathTemplate { get; private set; }
        public virtual string UpstreamHost { get; private set; }
        public virtual bool ReRouteIsCaseSensitive { get; private set; }
        public virtual string Aggregator { get; private set; }
        public virtual int? Priority { get; private set; }
    }
}
