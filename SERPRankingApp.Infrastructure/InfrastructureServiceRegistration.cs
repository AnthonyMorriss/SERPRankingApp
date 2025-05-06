using Microsoft.Extensions.DependencyInjection;
using SERPRankingApp.Application.Contracts;
using SERPRankingApp.Infrastructure.SearchScraper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERPRankingApp.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ISearchScraperService, SearchScraperService>();

            return services;
        }
    }
}
