using System.Threading.Tasks;
using Api.App.Controllers;
using Api.Domain.Dtos.Auth;
using Api.Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace Api.App.Test.Auth
{
    public class AuthTest : AuthFake
    {
        private readonly AuthController _controller;
        private readonly Mock<IAuthService> _serviceMock = new Mock<IAuthService>();

        public AuthTest()
        {
            _serviceMock
                .Setup(_ => _.Create(It.IsAny<AuthDtoCreate>()))
                .Returns(Task.FromResult(authDtoLoginResult));

            _serviceMock
                .Setup(_ => _.Login(It.IsAny<AuthDtoLogin>()))
                .Returns(Task.FromResult(authDtoLoginResult));

            _controller = new AuthController(_serviceMock.Object);
        }

        [Fact(DisplayName = "Should create auth")]
        public async Task Should_Create_Auth() {
            var result = await _controller.Create(authDtoCreate);
            Assert.NotNull(result);
        }

        [Fact(DisplayName = "Should login")]
        public async Task Should_Login() {
            var result = await _controller.Login(authDtoLogin);
            Assert.NotNull(result);
        }
    }
}