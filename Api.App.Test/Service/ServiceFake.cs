using System.Collections.Generic;
using Api.Domain.Dtos.Service;

namespace Api.App.Test.Service
{
    public class ServiceFake
    {
        public IEnumerable<ServiceDto> serviceDtoList = new List<ServiceDto>();
    }
}