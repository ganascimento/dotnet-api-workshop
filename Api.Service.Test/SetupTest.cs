using System;
using Api.CrossCutting.Mappings;
using AutoMapper;

namespace Api.Service.Test
{
    public class SetupTest
    {
        public IMapper Mapper { get; set; }

        public SetupTest()
        {
            Mapper = new AutoMapperFixture().GetMapper();
        }

        public class AutoMapperFixture : IDisposable {
            public IMapper GetMapper() {
                var autoMapperConfig = new MapperConfiguration(config =>
                {
                    config.AddProfile(new AuthMapping());
                    config.AddProfile(new ServiceMapping());
                    config.AddProfile(new ScheduleMapping());
                    config.AddProfile(new WorkshopMapping());
                });

                return autoMapperConfig.CreateMapper();
            }

            public void Dispose() {}
        }
    }
}