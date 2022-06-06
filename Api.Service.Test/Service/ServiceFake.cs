using System.Collections.Generic;
using Api.Domain.Entities;
using Bogus;

namespace Api.Service.Test.Service
{
    public class ServiceFake
    {
        public string Name { get; set; }
        public int WorkUnits { get; set; }

        public List<ServiceEntity> listServiceEntity = new List<ServiceEntity>();

        public ServiceFake()
        {
            var faker = new Faker("pt_BR");

            Name = faker.Name.JobTitle();
            WorkUnits = faker.Random.Number(10);

            for (var i = 0; i < 5; i++) {
                listServiceEntity.Add(new ServiceEntity {
                    Name = Name,
                    WorkUnits = WorkUnits
                });
            }
        }
    }
}