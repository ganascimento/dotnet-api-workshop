using Bogus;
using Api.Domain.Entities;

namespace Api.Infra.Test.Workshop
{
    public class WorkshopFake
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string Uf { get; set; }
        public int AuthId { get; set; }

        public WorkshopEntity workshopEntity;
        public WorkshopEntity workshopEntityInsert;

        public WorkshopFake()
        {
            var faker = new Faker("pt_BR");

            Name = faker.Company.CompanyName();
            Street = faker.Address.StreetName();
            Number = faker.Random.Number(1000);
            District = faker.Address.City();
            Uf = faker.Address.State();
            AuthId = faker.Random.Number(1000);

            workshopEntity = new WorkshopEntity {
                District = District,
                Name = Name,
                Street = Street,
                Number = Number,
                Uf = Uf,
                AuthId = AuthId
            };

            workshopEntityInsert = new WorkshopEntity {
                District = District,
                Name = faker.Company.CompanyName(),
                Street = Street,
                Number = Number,
                Uf = Uf,
                AuthId = AuthId
            };
        }
    }
}