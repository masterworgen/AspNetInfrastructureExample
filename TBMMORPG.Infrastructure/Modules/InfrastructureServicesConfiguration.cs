using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TBMMORPG.Infrastructure.Data;
using TBMMORPG.Infrastructure.Data.Interface;
using TBMMORPG.Infrastructure.Services;
using TBMMORPG.Infrastructure.Services.Interface;

namespace TBMMORPG.Infrastructure.Modules
{
    public static class InfrastructureServicesConfiguration
    {
        public static void AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            //if (env.IsDevelopment())
            //    services.AddDbContext<TBMMORPGContext>(options =>
            //        options.UseInMemoryDatabase(databaseName: "Test")); // Для локальных разработок

            services.AddDbContext<TBMMORPGContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IDbContext, TBMMORPGContext>();

            services.AddScoped<IUserService, UserService>();
        }
    }
}
