using Bogus;
using Bogus.Extensions.Brazil;
using Api.Domain.Dtos.Workshop;

namespace Api.App.Test.Workshop
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

        public WorkshopDtoUpdate workshopDtoUpdate;

        public WorkshopDto workshopDto;

        public WorkshopDtoUpdateResult workshopDtoUpdateResult;

        public WorkshopFake()
        {
            var faker = new Faker("pt_BR");

            Name = faker.Company.CompanyName();
            Street = faker.Address.StreetName();
            Number = faker.Random.Number(1000);
            District = faker.Address.City();
            Uf = faker.Address.State();
            AuthId = faker.Random.Number(1000);

            workshopDtoUpdate = new WorkshopDtoUpdate {
                District = District,
                Name = Name,
                Number = Number,
                Street = Street,
                Uf = Uf
            };

            workshopDto = new WorkshopDto {
                Cnpj = faker.Company.Cnpj(),
                Complement = Complement,
                District = District,
                Name = Name,
                Number = Number,
                Street = Street,
                Uf = Uf
            };

            workshopDtoUpdateResult = new WorkshopDtoUpdateResult {
                Complement = Complement,
                District = District,
                Name = Name,
                Number = Number,
                Street = Street,
                Uf = Uf
            };
        }
    }
}