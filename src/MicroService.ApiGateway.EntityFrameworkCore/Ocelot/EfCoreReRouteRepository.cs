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
    public class EfCoreReRouteRepository : ApiGatewayEfCoreRepositoryBase<ApiGatewayDbContext, ReRoute, int>, IReRouteRepository
    {
        public EfCoreReRouteRepository(IDbContextProvider<ApiGatewayDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }

        public async Task<ReRoute> GetByNameAsync(string routeName)
        {
            return await GetQueryable().Where(x => x.ReRouteName.Equals(routeName)).FirstOrDefaultAsync();
        }

        public async Task<ReRoute> GetByReRouteIdAsync(int routeId)
        {
            return await GetQueryable().Where(x => x.ReRouteId.Equals(routeId)).FirstOrDefaultAsync();
        }

        public async Task<(List<ReRoute> routes, long total)> GetPagedListAsync(int skipCount = 1, int maxResultCount = 100)
        {
            var resultReRoutes = await GetQueryable()
                .EfPageBy(skipCount, maxResultCount)
                .ToListAsync();

            var total = await GetQueryable().LongCountAsync();

            return ValueTuple.Create(resultReRoutes, total);
        }
    }
}
