using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Service;

namespace Api.Domain.Interfaces.Services
{
    public interface IServiceService
    {
        Task<IEnumerable<ServiceDto>> GetAll();
    }
}