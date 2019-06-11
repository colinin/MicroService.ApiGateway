using MicroService.ApiGateway.Entites.Ocelot;
using MicroService.ApiGateway.EntityFrameworkCore;
using MicroService.ApiGateway.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;

namespace MicroService.ApiGateway.Ocelot
{
    public class EfCoreAggregateReRouteRepository : ApiGatewayEfCoreRepositoryBase<ApiGatewayDbContext, AggregateReRoute, int>, IAggregateReRouteRepository
    {
        public EfCoreAggregateReRouteRepository(IDbContextProvider<ApiGatewayDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }

        public async Task<(List<AggregateReRoute> routes, long total)> GetPagedListAsync(int skipCount = 1, int maxResultCount = 100)
        {
            var resultReRoutes = await WithDetails()
             .EfPageBy(skipCount, maxResultCount)
             .ToListAsync();

            var total = await GetQueryable().LongCountAsync();

            return ValueTuple.Create(resultReRoutes, total);
        }
    }
}
