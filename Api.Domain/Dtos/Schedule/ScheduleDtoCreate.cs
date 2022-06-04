using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Schedule
{
    public class ScheduleDtoCreate
    {
        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "ServiceId is required")]
        public int ServiceId { get; set; }
    }
}