using System.Linq;
using System.Threading.Tasks;
using Api.Infra.Context;
using Api.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Api.Infra.Test.Schedule
{
    public class ScheduleTest : ScheduleFake
    {
        private ScheduleRepository _repository;
        private readonly DbContextOptions<DataContext> _options;

        public ScheduleTest()
        {
            _options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "Workshop").Options;

            using (var context = new DataContext(_options)) {
                context.Schedule.Add(scheduleEntity);
                context.SaveChanges();
            }
        }

        [Fact(DisplayName = "Should get period by single date")]
        public async Task Should_Get_Period_By_Single_Date() {
            using (var context = new DataContext(_options)) {
                _repository = new ScheduleRepository(context);

                var result = await _repository.SelectPeriodAsync(WorkshopId, Date);
                Assert.NotNull(result);
                Assert.Equal(result.Count(), 1);
                Assert.Equal(result.First().ServiceId, ServiceId);
                Assert.Equal(result.First().WorkshopId, WorkshopId);
            }
        }

        [Fact(DisplayName = "Should get period by two date")]
        public async Task Should_Get_Period_By_Two_Date() {
            using (var context = new DataContext(_options)) {
                _repository = new ScheduleRepository(context);

                var result = await _repository.SelectPeriodAsync(WorkshopId, Date, Date.AddDays(1));
                Assert.NotNull(result);
                Assert.Equal(result.Count(), 1);
                Assert.Equal(result.First().ServiceId, ServiceId);
                Assert.Equal(result.First().WorkshopId, WorkshopId);
            }
        }

        [Fact(DisplayName = "Should insert schedule")]
        public async Task Should_Insert_Schedule() {
            using (var context = new DataContext(_options)) {
                _repository = new ScheduleRepository(context);

                var result = await _repository.InsertAsync(scheduleEntityInsert);
                Assert.NotNull(result);
                Assert.Equal(result.Date, scheduleEntityInsert.Date);
                Assert.Equal(result.ServiceId, ServiceId);
                Assert.Equal(result.WorkshopId, WorkshopId);
            }
        }

        [Fact(DisplayName = "Should delete schedule")]
        public async Task Should_Delete_Schedule() {
            using (var context = new DataContext(_options)) {
                _repository = new ScheduleRepository(context);

                var resultInsert = await _repository.InsertAsync(scheduleEntityInsert);
                var result = await _repository.DeleteAsync(resultInsert.Id);
                Assert.NotNull(result);
                Assert.Equal(result, true);
            }
        }
    }
}