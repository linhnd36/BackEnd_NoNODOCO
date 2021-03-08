using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data_Tier.DBContext;
using Data_Tier.Models;
using ApiNoNODOCO.Service.IService;

namespace ApiNoNODOCO.Controllers
{
    [Route("api/v1/bookings")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var result = _bookingService.Get();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var result = _bookingService.Get(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<Action> Create(Booking booking)
        {
            var result = _bookingService.Create(booking);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update(Booking booking)
        {
            var result = _bookingService.Update(booking);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _bookingService.DeleteOne(id);

            if (result == null) return NotFound();
            return Ok(result);

        }
    }
}
