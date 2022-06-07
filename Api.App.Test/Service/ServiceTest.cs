using System.Threading.Tasks;
using Api.App.Controllers;
using Api.Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace Api.App.Test.Service
{
    public class ServiceTest : ServiceFake
    {
        private readonly ServiceController _controller;
        private readonly Mock<IServiceService> _serviceMock = new Mock<IServiceService>();

        public ServiceTest()
        {
            _serviceMock
                .Setup(_ => _.GetAll())
                .Returns(Task.FromResult(serviceDtoList));

            _controller = new ServiceController(_serviceMock.Object);
        }

        [Fact(DisplayName = "Should get all")]
        public async Task Should_Get_All() {
            var result = await _controller.GetAll();
            Assert.NotNull(result);
        }
    }
}