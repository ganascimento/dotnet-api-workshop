using System;

namespace Api.Domain.Dtos.Schedule
{
    public class ScheduleDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
    }
}