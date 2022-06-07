using System.Threading.Tasks;
using Api.Infra.Context;
using Api.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Api.Infra.Test.Auth
{
    public class AuthTest : AuthFake
    {
        private AuthRepository _repository;
        private readonly DbContextOptions<DataContext> _options;

        public AuthTest()
        {
            _options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "Workshop").Options;

            using (var context = new DataContext(_options)) {
                context.Auth.Add(authEntity);
                context.SaveChanges();
            }
        }

        [Fact(DisplayName = "Should get by cnpj")]
        public async Task Should_Get_By_Cnpj() {
            using (var context = new DataContext(_options)) {
                _repository = new AuthRepository(context);

                var result = await _repository.SelectByCnpjAsync(Cnpj);
                Assert.NotNull(result);
                Assert.Equal(result.Cnpj, Cnpj);
                Assert.Equal(result.Password, Password);
            }
        }

        [Fact(DisplayName = "Should insert auth")]
        public async Task Should_Insert_Auth() {
            using (var context = new DataContext(_options)) {
                _repository = new AuthRepository(context);

                var result = await _repository.InsertAsync(authEntityInsert);
                Assert.NotNull(result);
                Assert.Equal(result.Cnpj, authEntityInsert.Cnpj);
                Assert.Equal(result.Password, Password);
            }
        }

        [Fact(DisplayName = "Should remove auth")]
        public async Task Should_Remove_Auth() {
            using (var context = new DataContext(_options)) {
                _repository = new AuthRepository(context);

                var resultInsert = await _repository.InsertAsync(authEntityInsert);
                var result = await _repository.DeleteAsync(resultInsert.Id);
                Assert.NotNull(result);
                Assert.Equal(result, true);
            }
        }
    }
}