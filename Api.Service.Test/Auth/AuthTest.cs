using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Service.Security;
using Api.Service.Services;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace Api.Service.Test.Auth
{
    public class AuthTest : AuthFake
    {
        private readonly AuthService _service;
        private readonly Mock<IAuthRepository> _authRepositoryMock = new Mock<IAuthRepository>();
        private readonly Mock<IWorkshopRepository> _workshopRepositoryMock = new Mock<IWorkshopRepository>();
        private readonly IOptions<AppSettings> _appSettings = Options.Create<AppSettings>(new AppSettings {
            Audience = "PROJECT_API_WORKSHOP",
            Expiration = 12,
            Issuer = "PROJECT_API_WORKSHOP",
            Secret = "SERCRET_PARA_TESTE_ALEATORIO"
        });

        public AuthTest()
        {
            var setupTest = new SetupTest();
            _authRepositoryMock
                .Setup(_ => _.InsertAsync(It.IsAny<AuthEntity>()))
                .Returns(Task.FromResult(authEntity));

            _workshopRepositoryMock
                .Setup(_ => _.InsertAsync(It.IsAny<WorkshopEntity>()))
                .Returns(Task.FromResult(workshopEntity));

            _workshopRepositoryMock
                .Setup(_ => _.SelectByAuthIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(workshopEntity));

            _service = new AuthService(_authRepositoryMock.Object, _appSettings, _workshopRepositoryMock.Object, setupTest.Mapper);
        }

        [Fact(DisplayName = "Should create Auth and Workshop")]
        public async Task Should_Create_Auth() {
            _authRepositoryMock
                .Setup(_ => _.SelectByCnpjAsync(Cnpj))
                .Returns(Task.FromResult<AuthEntity>(null));

            var result = await _service.Create(authDtoCreate);
            Assert.NotNull(result);
            Assert.NotEmpty(result.AccessToken);
        }

        [Fact(DisplayName = "Should login")]
        public async Task Should_Login() {
            _authRepositoryMock
                .Setup(_ => _.SelectByCnpjAsync(Cnpj))
                .Returns(Task.FromResult(authEntityHash));

            var result = await _service.Login(authDtoLogin);
            Assert.NotNull(result);
            Assert.NotEmpty(result.AccessToken);
        }
    }
}