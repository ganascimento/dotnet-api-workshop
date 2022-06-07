using Api.Domain.Entities;
using Bogus;

namespace Api.Infra.Test.Service
{
    public class ServiceFake
    {
        public string Name { get; set; }
        public int WorkUnits { get; set; }

        public ServiceEntity serviceEntity;

        public ServiceFake()
        {
            var faker = new Faker("pt_BR");

            Name = faker.Name.JobTitle();
            WorkUnits = faker.Random.Number(10);

            serviceEntity = new ServiceEntity {
                Name = Name,
                WorkUnits = WorkUnits
            };
        }
    }
}