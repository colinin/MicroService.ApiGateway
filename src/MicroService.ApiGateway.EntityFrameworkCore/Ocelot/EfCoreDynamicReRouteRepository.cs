using MicroService.ApiGateway.Entites.Ocelot;
using MicroService.ApiGateway.EntityFrameworkCore;
using MicroService.ApiGateway.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;

namespace MicroService.ApiGateway.Ocelot
{
    public class EfCoreDynamicReRouteRepository : ApiGatewayEfCoreRepositoryBase<ApiGatewayDbContext, DynamicReRoute, int>, IDynamicReRouteRepository
    {
        public EfCoreDynamicReRouteRepository(IDbContextProvider<ApiGatewayDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {

        }

        public async Task<DynamicReRoute> GetByItemIdAsync(int itemId)
        {
            return await GetQueryable().Where(x => x.DunamicReRouteId.Equals(itemId)).FirstOrDefaultAsync();
        }
    }
}
