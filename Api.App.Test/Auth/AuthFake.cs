using System;
using Api.Domain.Dtos.Auth;
using Bogus;
using Bogus.Extensions.Brazil;

namespace Api.App.Test.Auth
{
    public class AuthFake
    {
        public static string Cnpj { get; set; }
        public static string Password { get; set; }

        public AuthDtoCreate authDtoCreate;
        public AuthDtoLogin authDtoLogin;

        public AuthDtoLoginResult authDtoLoginResult;

        public AuthFake()
        {
            var faker = new Faker("pt_BR");

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

            authDtoLoginResult = new AuthDtoLoginResult {
                AccessToken = Guid.NewGuid().ToString(),
                Authenticated = true,
                Expiration = DateTime.Now.AddHours(12)
            };
        }
    }
}