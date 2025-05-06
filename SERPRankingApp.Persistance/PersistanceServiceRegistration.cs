using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SERPRankingApp.Persistance.DatabaseContext;
using SERPRankingApp.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERPRankingApp.Persistance
{
    public static class PersistanceServiceRegistration
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SERPRankingDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DatabaseConnectionString"));
            });

            services.AddScoped<ISERPRankingRepository, SERPRankingRepository>();

            return services;
        }
    }
}
