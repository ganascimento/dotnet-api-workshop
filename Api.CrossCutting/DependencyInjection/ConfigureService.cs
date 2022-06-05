using Api.Domain.Interfaces.Services;
using Api.Service.Helpers;
using Api.Service.Helpers.interfaces;
using Api.Service.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public static class ConfigureService
    {
        public static void ConfigureDependenciesService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<IScheduleService, ScheduleService>();
            services.AddScoped<IWorkshopService, WorkshopService>();
            services.AddScoped<IIdentityService, IdentityService>();
        }
    }
}