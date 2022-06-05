using System.Threading.Tasks;
using Api.Domain.Dtos.Workshop;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Domain.Interfaces.Services;
using Api.Service.Helpers.interfaces;
using AutoMapper;

namespace Api.Service.Services
{
    public class WorkshopService : IWorkshopService
    {
        private readonly IWorkshopRepository _workshopRepository;
        private readonly IMapper _mapper;
        private readonly IIdentityService _identityService;

        public WorkshopService(
            IWorkshopRepository workshopRepository,
            IMapper mapper,
            IIdentityService identityService
        )
        {
            _workshopRepository = workshopRepository;
            _mapper = mapper;
            _identityService = identityService;
        }

        public async Task<WorkshopDto> Get()
        {
            var workshop = await _workshopRepository.SelectAsync(_identityService.GetWorkshopId());
            return _mapper.Map<WorkshopDto>(workshop);
        }

        public async Task<bool> Remove()
        {
            return await _workshopRepository.DeleteAsync(_identityService.GetWorkshopId());
        }

        public async Task<WorkshopDtoUpdateResult> Update(WorkshopDtoUpdate dto)
        {
            var workshop = _mapper.Map<WorkshopEntity>(dto);
            workshop.Id = _identityService.GetWorkshopId();
            workshop.AuthId = _identityService.GetAuthId();
            workshop = await _workshopRepository.UpdateAsync(workshop);

            return _mapper.Map<WorkshopDtoUpdateResult>(workshop);
        }
    }
}