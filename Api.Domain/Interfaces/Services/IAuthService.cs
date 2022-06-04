using System.Threading.Tasks;
using Api.Domain.Dtos.Auth;

namespace Api.Domain.Interfaces.Services
{
    public interface IAuthService
    {
        Task<AuthDtoLoginResult> Create(AuthDtoCreate dto);
        Task<AuthDtoLoginResult> Login(AuthDtoLogin dto);
    }
}