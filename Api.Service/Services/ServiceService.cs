using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Service;
using Api.Domain.Interfaces.Repositories;
using Api.Domain.Interfaces.Services;
using AutoMapper;
using System.Linq;

namespace Api.Service.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;

        public ServiceService(
            IServiceRepository serviceRepository,
            IMapper mapper
        )
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ServiceDto>> GetAll()
        {
            var services = await _serviceRepository.SelectAsync();
            return services.Select(x => _mapper.Map<ServiceDto>(x));
        }
    }
}