using System;
using Api.Domain.Interfaces.Repositories;
using Api.Domain.Interfaces.Repositories.Base;
using Api.Infra.Context;
using Api.Infra.Repositories;
using Api.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IScheduleRepository, ScheduleRepository>();
            services.AddScoped<IWorkshopRepository, WorkshopRepository>();

            services.AddDbContext<DataContext>(
                options => options.UseMySql(
                    configuration.GetConnectionString("DefaultConnection"),
                    new MySqlServerVersion(new Version(8, 0, 27))
                )
            );
        }
    }
}