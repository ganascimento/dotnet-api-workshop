using System;
using Api.Domain.Entities.Base;

namespace Api.Domain.Entities
{
    public class ScheduleEntity : BaseEntity
    {
        public DateTime Date { get; set; }
        public int ServiceId { get; set; }
        public int WorkshopId { get; set; }

        public virtual ServiceEntity Service { get; set; }
        public virtual WorkshopEntity Workshop { get; set; }
    }
}