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
    [Route("api/v1/driverAvaiabilities")]
    [ApiController]
    public class DriverAvaiabilitiesController : ControllerBase
    {
        private IDriverAvaiabilityService _driverAvaiabilityService;

        public DriverAvaiabilitiesController(IDriverAvaiabilityService driverAvaiabilityService)
        {
            _driverAvaiabilityService = driverAvaiabilityService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var result = _driverAvaiabilityService.Get();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var result = _driverAvaiabilityService.Get(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<Action> Create(DriverAvaiability driverAvaiability)
        {
            var result = _driverAvaiabilityService.Create(driverAvaiability);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update(DriverAvaiability driverAvaiability)
        {
            var result = _driverAvaiabilityService.Update(driverAvaiability);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _driverAvaiabilityService.DeleteOne(id);

            if (result == null) return NotFound();
            return Ok(result);

        }
    }
}
