using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Service.Helpers.interfaces;
using Api.Service.Services;
using Moq;
using Xunit;

namespace Api.Service.Test.Workshop
{
    public class WorkshopTest : WorkshopFake
    {
        private readonly WorkshopService _service;
        private readonly Mock<IWorkshopRepository> _workshopRepositoryMock = new Mock<IWorkshopRepository>();
        private readonly Mock<IAuthRepository> _authRepositoryMock = new Mock<IAuthRepository>();
        private readonly Mock<IIdentityService> _identityServiceMock = new Mock<IIdentityService>();

        public WorkshopTest()
        {
            var setupTest = new SetupTest();

            _workshopRepositoryMock
                .Setup(_ => _.SelectAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(workshopEntity));

            _workshopRepositoryMock
                .Setup(_ => _.UpdateAsync(It.IsAny<WorkshopEntity>()))
                .Returns(Task.FromResult(workshopEntity));

            _workshopRepositoryMock
                .Setup(_ => _.DeleteAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(true));

            _authRepositoryMock
                .Setup(_ => _.DeleteAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(true));

            _identityServiceMock
                .Setup(_ => _.GetAuthId())
                .Returns(1);

            _identityServiceMock
                .Setup(_ => _.GetWorkshopId())
                .Returns(1);

            _service = new WorkshopService(_workshopRepositoryMock.Object, _authRepositoryMock.Object, setupTest.Mapper, _identityServiceMock.Object);
        }

        [Fact(DisplayName = "Should get workshop")]
        public async Task Should_Get_Workshop() {
            var result = await _service.Get();
            Assert.NotNull(result);
            Assert.Equal(result.Name, Name);
            Assert.Equal(result.Street, Street);
            Assert.Equal(result.Number, Number);
            Assert.Equal(result.District, District);
            Assert.Equal(result.Uf, Uf);
        }
        
        [Fact(DisplayName = "Should update workshop")]
        public async Task Should_Update_Workshop() {
            var result = await _service.Update(workshopDtoUpdate);
            Assert.NotNull(result);
            Assert.Equal(result.Name, Name);
            Assert.Equal(result.Street, Street);
            Assert.Equal(result.Number, Number);
            Assert.Equal(result.District, District);
            Assert.Equal(result.Uf, Uf);
        }
        [Fact(DisplayName = "Should remove workshop")]
        public async Task Should_Remove_Workshop() {
            var result = await _service.Remove();
            Assert.NotNull(result);
            Assert.Equal(result, true);
        }
    }
}