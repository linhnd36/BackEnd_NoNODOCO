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
    [Route("api/v1/vehicles")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private IVehicleService _vehicleService;

        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var result = _vehicleService.Get();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var result = _vehicleService.Get(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<Action> Create(Vehicle vehicle)
        {
            var result = _vehicleService.Create(vehicle);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update(Vehicle vehicle)
        {
            var result = _vehicleService.Update(vehicle);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _vehicleService.DeleteOne(id);

            if (result == null) return NotFound();
            return Ok(result);

        }
    }
}
