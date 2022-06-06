using Bogus;
using Api.Domain.Entities;
using Api.Domain.Dtos.Workshop;

namespace Api.Service.Test.Workshop
{
    public class WorkshopFake
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string Uf { get; set; }
        public int AuthId { get; set; }

        public WorkshopEntity workshopEntity;

        public WorkshopDtoUpdate workshopDtoUpdate;

        public WorkshopFake()
        {
            var faker = new Faker("pt_BR");

            Id = faker.IndexFaker;
            Name = faker.Company.CompanyName();
            Street = faker.Address.StreetName();
            Number = faker.Random.Number(1000);
            District = faker.Address.City();
            Uf = faker.Address.State();
            AuthId = faker.IndexFaker;

            workshopEntity = new WorkshopEntity {
                AuthId = AuthId,
                District = District,
                Id = Id,
                Name = Name,
                Street = Street,
                Number = Number,
                Uf = Uf
            };

            workshopDtoUpdate = new WorkshopDtoUpdate {
                District = District,
                Name = Name,
                Number = Number,
                Street = Street,
                Uf = Uf
            };
        }
    }
}