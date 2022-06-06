using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Service.Helpers.interfaces;
using Api.Service.Services;
using Moq;
using Xunit;

namespace Api.Service.Test.Schedule
{
    public class ScheduleTest : ScheduleFake
    {
        private readonly ScheduleService _service;
        private readonly Mock<IScheduleRepository> _scheduleRepositoryMock = new Mock<IScheduleRepository>();
        private readonly Mock<IServiceRepository> _serviceRepositoryMock = new Mock<IServiceRepository>();
        private readonly Mock<IIdentityService> _identityServiceMock = new Mock<IIdentityService>();

        public ScheduleTest()
        {
            var setupTest = new SetupTest();

            _scheduleRepositoryMock
                .Setup(_ => _.SelectPeriodAsync(It.IsAny<int>(), It.IsAny<DateTime>()))
                .Returns(Task.FromResult(scheduleEntityList.AsEnumerable()));

            _scheduleRepositoryMock
                .Setup(_ => _.SelectPeriodAsync(It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .Returns(Task.FromResult(scheduleEntityList.AsEnumerable()));

            _scheduleRepositoryMock
                .Setup(_ => _.InsertAsync(It.IsAny<ScheduleEntity>()))
                .Returns(Task.FromResult(scheduleEntity));

            _scheduleRepositoryMock
                .Setup(_ => _.DeleteAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(true));

            _serviceRepositoryMock
                .Setup(_ => _.SelectAsync())
                .Returns(Task.FromResult(listServiceEntity.AsEnumerable()));

            _identityServiceMock
                .Setup(_ => _.GetAuthId())
                .Returns(1);

            _identityServiceMock
                .Setup(_ => _.GetWorkshopId())
                .Returns(1);

            _service = new ScheduleService(_scheduleRepositoryMock.Object, setupTest.Mapper, _serviceRepositoryMock.Object, _identityServiceMock.Object);
        }

        [Fact(DisplayName = "Should get today schedule")]
        public async Task Should_Get_Today_Schedule() {
            var result = await _service.GetToday();
            Assert.NotNull(result);
        }

        [Fact(DisplayName = "Should get period schedule")]
        public async Task Should_Get_Period_Schedule() {
            var result = await _service.GetPeriod();
            Assert.NotNull(result);
        }

        [Fact(DisplayName = "Should get period with start and end date schedule")]
        public async Task Should_Get_Period_With_Start_And_End_Date_Schedule() {
            var result = await _service.GetPeriod(DateTime.Now, DateTime.Now.AddDays(1));
            Assert.NotNull(result);
        }

        [Fact(DisplayName = "Should get available work load schedule")]
        public async Task Should_Get_Available_Work_Load_Schedule() {
            var result = await _service.GetAvailableWorkLoad();
            Assert.NotNull(result);
        }

        [Fact(DisplayName = "Should create schedule")]
        public async Task Should_Create_Schedule() {
            var result = await _service.Create(scheduleDtoCreate);
            Assert.NotNull(result);
        }

        [Fact(DisplayName = "Should remove schedule")]
        public async Task Should_Remoce_Schedule() {
            var result = await _service.Remove(1);
            Assert.NotNull(result);
        }
    }
}