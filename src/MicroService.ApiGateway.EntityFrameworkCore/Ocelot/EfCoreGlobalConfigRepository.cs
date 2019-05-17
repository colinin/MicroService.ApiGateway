using MicroService.ApiGateway.Entites.Ocelot;
using MicroService.ApiGateway.EntityFrameworkCore;
using MicroService.ApiGateway.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;

namespace MicroService.ApiGateway.Ocelot
{
    public class EfCoreGlobalConfigRepository : ApiGatewayEfCoreRepositoryBase<ApiGatewayDbContext, GlobalConfiguration, int>, IGlobalConfigRepository
    {
        public EfCoreGlobalConfigRepository(IDbContextProvider<ApiGatewayDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {

        }

        public async Task<GlobalConfiguration> GetByItemIdAsync(int itemId)
        {
            return await GetQueryable().Where(x => x.ItemId.Equals(itemId)).FirstOrDefaultAsync();
        }

        public async Task<GlobalConfiguration> GetOneAsync()
        {
            return await GetQueryable().FirstOrDefaultAsync();
        }
    }
}
