using System;
using System.Collections.Generic;
using Api.Domain.Dtos.Schedule;
using Bogus;

namespace Api.App.Test.Schedule
{
    public class ScheduleFake
    {
        public DateTime Date { get; set; }
        public int ServiceId { get; set; }
        public int WorkshopId { get; set; }

        public ScheduleDtoCreate scheduleDtoCreate;

        public ScheduleDtoCreateResult scheduleDtoCreateResult;

        public IEnumerable<ScheduleDto> scheduleDtoList = new List<ScheduleDto>();

        public IEnumerable<ScheduleDtoAvailableWorkLoad> scheduleDtoAvailableWorkLoadList = new List<ScheduleDtoAvailableWorkLoad>();

        public ScheduleFake()
        {
            var faker = new Faker("pt_BR");

            Date = DateTime.Now;
            ServiceId = faker.Random.Number(1000);
            WorkshopId = faker.Random.Number(1000);

            scheduleDtoCreate = new ScheduleDtoCreate {
                Date = Date,
                ServiceId = ServiceId
            };

            scheduleDtoCreateResult = new ScheduleDtoCreateResult {
                Date = Date,
                ServiceId = ServiceId,
                ServiceName = faker.Name.JobTitle()
            };
        }
    }
}