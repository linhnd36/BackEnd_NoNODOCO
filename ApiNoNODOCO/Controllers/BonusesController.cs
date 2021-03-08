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
    [Route("api/v1/bonuses")]
    [ApiController]
    public class BonusesController : ControllerBase
    {
        private IBonusService _bonusService;

        public BonusesController(IBonusService bonusService)
        {
            _bonusService = bonusService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var result = _bonusService.Get();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var result = _bonusService.Get(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<Action> Create(Bonus bonus)
        {
            var result = _bonusService.Create(bonus);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update(Bonus bonus)
        {
            var result = _bonusService.Update(bonus);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _bonusService.DeleteOne(id);

            if (result == null) return NotFound();
            return Ok(result);

        }
    }
}
