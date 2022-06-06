using Api.Domain.Dtos.Auth;
using Api.Domain.Entities;
using Bogus;
using Bogus.Extensions.Brazil;

namespace Api.Service.Test.Auth
{
    public class AuthFake
    {
        public static int Id { get; set; }
        public static string Cnpj { get; set; }
        public static string Password { get; set; }

        public AuthDtoCreate authDtoCreate;
        public AuthDtoLogin authDtoLogin;

        public AuthEntity authEntity;
        public AuthEntity authEntityHash;

        public WorkshopEntity workshopEntity;

        public AuthFake()
        {
            var faker = new Faker("pt_BR");

            Id = faker.IndexFaker;
            Cnpj = faker.Company.Cnpj(includeFormatSymbols: false);
            Password = "12345678";

            authDtoCreate = new AuthDtoCreate {
                Cnpj = Cnpj,
                Name = faker.Company.CompanyName(),
                Password = Password,
                District = faker.Address.City(),
                Number = faker.Random.Number(1000),
                Street = faker.Address.StreetName(),
                Uf = faker.Address.State()
            };

            authDtoLogin = new AuthDtoLogin {
                Cnpj = Cnpj,
                Password = Password
            };

            authEntity = new AuthEntity {
                Id = Id,
                Cnpj = Cnpj,
                Password = Password
            };

            authEntityHash = new AuthEntity {
                Id = Id,
                Cnpj = Cnpj,
                Password = "XwCCdhqrVt8HMrtMhG+azb1ROvs2eAfF6hGdQWwgQm1Q0x4j"
            };

            workshopEntity = new WorkshopEntity {
                AuthId = faker.IndexFaker,
                District = faker.Address.City(),
                Number = faker.Random.Number(1000),
                Street = faker.Address.StreetName(),
                Uf = faker.Address.State(),
                Id = faker.IndexFaker,
                Name = faker.Company.CompanyName()
            };
        }
    }
}