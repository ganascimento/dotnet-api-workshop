using Api.Domain.Entities.Base;

namespace Api.Domain.Entities
{
    public class ServiceEntity : BaseEntity
    {
        public string Name { get; set; }
        public int WorkUnits { get; set; }
    }
}