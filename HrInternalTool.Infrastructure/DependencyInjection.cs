using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HrInternalTool.Domain.Interfaces;
using HrInternalTool.Infrastructure.Data;
using HrInternalTool.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HrInternalTool.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HrDataDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

                
            });

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IPerformanceReviewRepository, PerformanceReviewRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
