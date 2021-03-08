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
    [Route("api/v1/driverHaveBonus")]
    [ApiController]
    public class DriverHaveBonusController : ControllerBase
    {
        private IDriverHaveBonusService _driverHaveBonusService;

        public DriverHaveBonusController(IDriverHaveBonusService driverHaveBonusService)
        {
            _driverHaveBonusService = driverHaveBonusService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var result = _driverHaveBonusService.Get();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var result = _driverHaveBonusService.Get(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<Action> Create(DriverHaveBonus driverHaveBonus)
        {
            var result = _driverHaveBonusService.Create(driverHaveBonus);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update(DriverHaveBonus driverHaveBonus)
        {
            var result = _driverHaveBonusService.Update(driverHaveBonus);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _driverHaveBonusService.DeleteOne(id);

            if (result == null) return NotFound();
            return Ok(result);

        }
    }
}
