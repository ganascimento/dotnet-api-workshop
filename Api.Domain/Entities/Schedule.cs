using System;

namespace Api.Domain.Entities
{
    public class Schedule : BaseEntity
    {
        public DateTime Date { get; set; }
        public int ServiceId { get; set; }
        public int WorkshopId { get; set; }

        public virtual Service Service { get; set; }
        public virtual WorkshopEntity Workshop { get; set; }
    }
}