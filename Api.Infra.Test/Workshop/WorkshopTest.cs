using System.Threading.Tasks;
using Api.Infra.Context;
using Api.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Api.Infra.Test.Workshop
{
    public class WorkshopTest : WorkshopFake
    {
        private WorkshopRepository _repository;
        private readonly DbContextOptions<DataContext> _options;

        public WorkshopTest()
        {
            _options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "Workshop").Options;

            using (var context = new DataContext(_options)) {
                context.Workshop.Add(workshopEntity);
                context.SaveChanges();
            }
        }

        [Fact(DisplayName = "Should get by auth id")]
        public async Task Should_Get_By_Auth_Id() {
            using (var context = new DataContext(_options)) {
                _repository = new WorkshopRepository(context);

                var result = await _repository.SelectByAuthIdAsync(AuthId);
                Assert.NotNull(result);
                Assert.Equal(result.Name, Name);
                Assert.Equal(result.Street, Street);
                Assert.Equal(result.Number, Number);
                Assert.Equal(result.District, District);
                Assert.Equal(result.Uf, Uf);
            }
        }

        [Fact(DisplayName = "Should get by id")]
        public async Task Should_Get_By_Id() {
            using (var context = new DataContext(_options)) {
                _repository = new WorkshopRepository(context);

                var resultInsert = await _repository.InsertAsync(workshopEntityInsert);
                var result = await _repository.SelectAsync(resultInsert.Id);
                Assert.NotNull(result);
                Assert.Equal(result.Name, workshopEntityInsert.Name);
                Assert.Equal(result.Street, workshopEntityInsert.Street);
                Assert.Equal(result.Number, workshopEntityInsert.Number);
                Assert.Equal(result.District, workshopEntityInsert.District);
                Assert.Equal(result.Uf, workshopEntityInsert.Uf);
            }
        }

        [Fact(DisplayName = "Should insert workshop")]
        public async Task Should_Insert_Workshop() {
            using (var context = new DataContext(_options)) {
                _repository = new WorkshopRepository(context);

                var result = await _repository.InsertAsync(workshopEntityInsert);
                Assert.NotNull(result);
                Assert.Equal(result.Name, workshopEntityInsert.Name);
                Assert.Equal(result.Street, workshopEntityInsert.Street);
                Assert.Equal(result.Number, workshopEntityInsert.Number);
                Assert.Equal(result.District, workshopEntityInsert.District);
                Assert.Equal(result.Uf, Uf);
            }
        }

        [Fact(DisplayName = "Should update workshop")]
        public async Task Should_Update_Workshop() {
            using (var context = new DataContext(_options)) {
                _repository = new WorkshopRepository(context);
                var newStreetName = "Test";

                var resultInsert = await _repository.InsertAsync(workshopEntityInsert);
                resultInsert.Street = newStreetName;
                var result = await _repository.UpdateAsync(resultInsert);
                Assert.NotNull(result);
                Assert.Equal(result.Name, workshopEntityInsert.Name);
                Assert.Equal(result.Street, newStreetName);
                Assert.Equal(result.Number, workshopEntityInsert.Number);
                Assert.Equal(result.District, workshopEntityInsert.District);
                Assert.Equal(result.Uf, workshopEntityInsert.Uf);
            }
        }

        [Fact(DisplayName = "Should delete workshop")]
        public async Task Should_Delete_Workshop() {
            using (var context = new DataContext(_options)) {
                _repository = new WorkshopRepository(context);

                var resultInsert = await _repository.InsertAsync(workshopEntityInsert);
                var result = await _repository.DeleteAsync(resultInsert.Id);
                Assert.NotNull(result);
                Assert.Equal(result, true);
            }
        }
    }
}