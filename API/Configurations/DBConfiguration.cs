
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Data;
using Microsoft.AspNetCore.Http;

namespace API.Configurations
{
    public static class DBConfiguration
    {



        
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<TenantContext>();

        }

    }
}
