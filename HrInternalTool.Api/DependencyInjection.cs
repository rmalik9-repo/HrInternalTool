using HrInternalTool.Application;
using HrInternalTool.Infrastructure;

namespace HrInternalTool.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiDI(this IServiceCollection services)
        {
            services.AddApplicationDI().AddInfrastructureDI();
            return services;
        }
    }
}
