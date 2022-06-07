using System.Threading.Tasks;
using Api.App.Controllers;
using Api.Domain.Dtos.Workshop;
using Api.Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace Api.App.Test.Workshop
{
    public class WorkshopTest : WorkshopFake
    {
        private readonly WorkshopController _controller;
        private readonly Mock<IWorkshopService> _serviceMock = new Mock<IWorkshopService>();

        public WorkshopTest()
        {
            _serviceMock
                .Setup(_ => _.Get())
                .Returns(Task.FromResult(workshopDto));

            _serviceMock
                .Setup(_ => _.Update(It.IsAny<WorkshopDtoUpdate>()))
                .Returns(Task.FromResult(workshopDtoUpdateResult));

            _serviceMock
                .Setup(_ => _.Remove())
                .Returns(Task.FromResult(true));

            _controller = new WorkshopController(_serviceMock.Object);
        }

        [Fact(DisplayName = "Should get")]
        public async Task Should_Get() {
            var result = await _controller.Get();
            Assert.NotNull(result);
        }

        [Fact(DisplayName = "Should update workshop")]
        public async Task Should_Update_Workshop() {
            var result = await _controller.Update(workshopDtoUpdate);
            Assert.NotNull(result);
        }

        [Fact(DisplayName = "Should remove workshop")]
        public async Task Should_Remove_Workshop() {
            var result = await _controller.Remove();
            Assert.NotNull(result);
        }
    }
}