﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PoznajmySie.CustomValidator;
using PoznajmySie.Models;
using PoznajmySie.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoznajmySie.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalendarController : ControllerBase
    {
        private readonly ILogger<CalendarController> _logger;
        private readonly ICalendarService _service;

        public CalendarController(ILogger<CalendarController> logger, ICalendarService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost("getfreeintervals")]
        public IActionResult GetFreeIntervals([FromBody] GetFreeIntervalsRequest request)
        {
            return Ok(new GetFreeIntervalsResponse(_service.GetFreeTimeIntervals(TimeSpan.Parse(request.MeetingDuration), request.Calendars)));
        }
    }
}
