using Api.CrossCutting.Mappings;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            var autoMapperConfig = new AutoMapper.MapperConfiguration(config =>
            {
                config.AddProfile(new AuthMapping());
                config.AddProfile(new ServiceMapping());
                config.AddProfile(new ScheduleMapping());
                config.AddProfile(new WorkshopMapping());
            });

            IMapper mapper = autoMapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}