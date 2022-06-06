using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.Schedule;
using Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.App.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            try {
                var result = await _scheduleService.GetToday();
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("period")]
        public async Task<IActionResult> GetPeriod() {
            try {
                var result = await _scheduleService.GetPeriod();
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("report")]
        public async Task<IActionResult> GetPeriod([FromQuery] DateTime startDate, [FromQuery] DateTime endDate) {
            try {
                var result = await _scheduleService.GetPeriod(startDate, endDate);
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableWorkLoad() {
            try {
                var result = await _scheduleService.GetAvailableWorkLoad();
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ScheduleDtoCreate dto) {
            try {
                var result = await _scheduleService.Create(dto);
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Remove([FromQuery] int id) {
            try {
                var result = await _scheduleService.Remove(id);
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}