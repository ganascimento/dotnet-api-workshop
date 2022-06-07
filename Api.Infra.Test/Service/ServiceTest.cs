using System.Linq;
using System.Threading.Tasks;
using Api.Infra.Context;
using Api.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Api.Infra.Test.Service
{
    public class ServiceTest : ServiceFake
    {
        private ServiceRepository _repository;
        private readonly DbContextOptions<DataContext> _options;

        public ServiceTest()
        {
            _options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "Workshop").Options;

            using (var context = new DataContext(_options)) {
                context.Service.Add(serviceEntity);
                context.SaveChanges();
            }
        }

        [Fact(DisplayName = "Should select all")]
        public async Task Should_Select_All() {
            using (var context = new DataContext(_options)) {
                _repository = new ServiceRepository(context);

                var result = await _repository.SelectAsync();
                Assert.NotNull(result);
                Assert.Equal(result.Count(), 1);
                Assert.Equal(result.First().Name, Name);
            }
        }
    }
}