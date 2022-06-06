using System;
using System.Collections.Generic;
using Api.Domain.Dtos.Schedule;
using Api.Domain.Entities;
using Bogus;

namespace Api.Service.Test.Schedule
{
    public class ScheduleFake
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ServiceId { get; set; }
        public int WorkshopId { get; set; }

        public ScheduleDtoCreate scheduleDtoCreate;

        public ScheduleEntity scheduleEntity;

        public List<ScheduleEntity> scheduleEntityList = new List<ScheduleEntity>();

        public List<ServiceEntity> listServiceEntity = new List<ServiceEntity>();

        public ScheduleFake()
        {
            var faker = new Faker("pt_BR");

            Id = faker.IndexFaker;
            Date = DateTime.Now;
            ServiceId = 1;
            WorkshopId = faker.IndexFaker;

            scheduleDtoCreate = new ScheduleDtoCreate {
                Date = Date,
                ServiceId = ServiceId
            };

            scheduleEntity = new ScheduleEntity {
                Id = Id,
                Date = Date,
                ServiceId = 1,
                WorkshopId = WorkshopId
            };

            scheduleEntityList.Add(scheduleEntity);

            for (var i = 0; i < 5; i++) {
                listServiceEntity.Add(new ServiceEntity {
                    Id = 1,
                    Name = faker.Company.CompanyName(),
                    WorkUnits = faker.Random.Number(10)
                });
            }
        }
    }
}