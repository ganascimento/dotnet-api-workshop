using Api.Domain.Entities;
using Bogus;
using Bogus.Extensions.Brazil;

namespace Api.Infra.Test.Auth
{
    public class AuthFake
    {
        public static int Id { get; set; }
        public string Cnpj { get; set; }
        public string Password { get; set; }
        public AuthEntity authEntity;
        public AuthEntity authEntityInsert;

        public AuthFake()
        {
            var faker = new Faker("pt_BR");

            Cnpj = faker.Company.Cnpj(includeFormatSymbols: false);
            Password = "12345678";

            authEntity = new AuthEntity {
                Cnpj = Cnpj,
                Password = Password
            };

            authEntityInsert = new AuthEntity {
                Cnpj = faker.Company.Cnpj(includeFormatSymbols: false),
                Password = Password
            };
        }
    }
}