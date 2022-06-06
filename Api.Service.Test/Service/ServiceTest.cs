using System.Threading.Tasks;
using Api.Domain.Interfaces.Repositories;
using Api.Service.Services;
using Moq;
using System.Linq;
using Xunit;

namespace Api.Service.Test.Service
{
    public class ServiceTest : ServiceFake
    {
        private readonly ServiceService _service;
        private readonly Mock<IServiceRepository> _serviceRepositoryMock = new Mock<IServiceRepository>();

        public ServiceTest()
        {
            var setupTest = new SetupTest();
            _serviceRepositoryMock
                .Setup(_ => _.SelectAsync())
                .Returns(Task.FromResult(listServiceEntity.AsEnumerable()));

            _service = new ServiceService(_serviceRepositoryMock.Object, setupTest.Mapper);
        }

        [Fact(DisplayName = "Should get all services")]
        public async Task Should_Get_All_Services() {
            var result = await _service.GetAll();
            Assert.NotNull(result);
            Assert.Equal(result.Count(), 5);
        }
    }
}