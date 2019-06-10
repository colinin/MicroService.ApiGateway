using MicroService.ApiGateway.Entites.Ocelot;
using MicroService.ApiGateway.EntityFrameworkCore;
using MicroService.ApiGateway.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.EntityFrameworkCore;

namespace MicroService.ApiGateway.Ocelot
{
    public class EfCoreGlobalConfigRepository : ApiGatewayEfCoreRepositoryBase<ApiGatewayDbContext, GlobalConfiguration, int>, IGlobalConfigRepository
    {
        public EfCoreGlobalConfigRepository(IDbContextProvider<ApiGatewayDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {

        }

        public async Task<GlobalConfiguration> GetByItemIdAsync(long itemId)
        {
            var globalConfiguration = await WithDetails().Where(x => x.ItemId.Equals(itemId)).FirstOrDefaultAsync();
            if(globalConfiguration == null)
            {
                throw new EntityNotFoundException(typeof(GlobalConfiguration));
            }
            return globalConfiguration;
        }

        public async Task<GlobalConfiguration> GetOneAsync()
        {
            return await WithDetails()
                .FirstOrDefaultAsync();
        }

        public override IQueryable<GlobalConfiguration> WithDetails()
        {
            return WithDetails(
                x => x.HttpHandlerOptions,
                x => x.LoadBalancerOptions,
                x => x.QoSOptions,
                x => x.RateLimitOptions,
                x => x.ServiceDiscoveryProvider);
        }
    }
}
