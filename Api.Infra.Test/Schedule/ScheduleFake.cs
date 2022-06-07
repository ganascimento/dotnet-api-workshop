using System;
using Api.Domain.Entities;
using Bogus;

namespace Api.Infra.Test.Schedule
{
    public class ScheduleFake
    {
        public DateTime Date { get; set; }
        public int ServiceId { get; set; }
        public int WorkshopId { get; set; }

        public ScheduleEntity scheduleEntity;
        public ScheduleEntity scheduleEntityInsert;

        public ScheduleFake()
        {
            var faker = new Faker("pt_BR");
            
            Date = DateTime.Now;
            ServiceId = faker.Random.Number(1000);
            WorkshopId = faker.Random.Number(1000);

            scheduleEntity = new ScheduleEntity {
                Date = Date,
                ServiceId = ServiceId,
                WorkshopId = WorkshopId
            };

            scheduleEntityInsert = new ScheduleEntity {
                Date = DateTime.Now.AddDays(1),
                ServiceId = ServiceId,
                WorkshopId = WorkshopId
            };
        }
    }
}