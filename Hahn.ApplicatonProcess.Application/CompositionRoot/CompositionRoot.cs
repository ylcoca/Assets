using Hahn.ApplicatonProcess.July2021.Data;
using Hahn.ApplicatonProcess.July2021.Data.Repository;
using Hahn.ApplicatonProcess.July2021.Domain.BussinessLogic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicatonProcess.July2021.Root
{
    public class CompositionRoot
    {
        public CompositionRoot()
        {

        }

        public static void injectDependencies(IServiceCollection services)
        {
            services.AddDbContext<DBContext>(opt => opt.UseInMemoryDatabase(databaseName: "user_asset_db"));
            services.AddScoped<DBContext>();
            services.AddScoped<IService, Service>();
            services.AddScoped<IUserAssetRepository, UserAssetRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

    }
}
