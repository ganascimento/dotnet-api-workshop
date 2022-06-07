using System;
using System.Threading.Tasks;
using Api.App.Controllers;
using Api.Domain.Dtos.Schedule;
using Api.Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace Api.App.Test.Schedule
{
    public class ScheduleTest : ScheduleFake
    {
        private readonly ScheduleController _controller;
        private readonly Mock<IScheduleService> _serviceMock = new Mock<IScheduleService>();

        public ScheduleTest()
        {
            _serviceMock
                .Setup(_ => _.GetToday())
                .Returns(Task.FromResult(scheduleDtoList));

            _serviceMock
                .Setup(_ => _.GetPeriod())
                .Returns(Task.FromResult(scheduleDtoList));

            _serviceMock
                .Setup(_ => _.GetPeriod(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .Returns(Task.FromResult(scheduleDtoList));

            _serviceMock
                .Setup(_ => _.GetAvailableWorkLoad())
                .Returns(Task.FromResult(scheduleDtoAvailableWorkLoadList));

            _serviceMock
                .Setup(_ => _.Create(It.IsAny<ScheduleDtoCreate>()))
                .Returns(Task.FromResult(scheduleDtoCreateResult));

            _serviceMock
                .Setup(_ => _.Remove(It.IsAny<int>()))
                .Returns(Task.FromResult(true));

            _controller = new ScheduleController(_serviceMock.Object);
        }

        [Fact(DisplayName = "Should get today")]
        public async Task Should_Get_Today() {
            var result = await _controller.GetToday();
            Assert.NotNull(result);
        }

        [Fact(DisplayName = "Should get period")]
        public async Task Should_Get_Period() {
            var result = await _controller.GetPeriod();
            Assert.NotNull(result);
        }

        [Fact(DisplayName = "Should get report")]
        public async Task Should_Get_Report() {
            var result = await _controller.GetPeriod(DateTime.Now, DateTime.Now.AddDays(10));
            Assert.NotNull(result);
        }

        [Fact(DisplayName = "Should get available work load")]
        public async Task Should_Get_Available_Work_Load() {
            var result = await _controller.GetAvailableWorkLoad();
            Assert.NotNull(result);
        }

        [Fact(DisplayName = "Should create schedule")]
        public async Task Should_Create_Schedule() {
            var result = await _controller.Create(scheduleDtoCreate);
            Assert.NotNull(result);
        }

        [Fact(DisplayName = "Should remove schedule")]
        public async Task Should_Remove_Schedule() {
            var result = await _controller.Remove(1);
            Assert.NotNull(result);
        }
    }
}