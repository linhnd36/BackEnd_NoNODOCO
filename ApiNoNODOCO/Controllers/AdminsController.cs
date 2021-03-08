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
using Microsoft.AspNetCore.Authorization;

namespace ApiNoNODOCO.Controllers
{
    [Route("api/v1/admins")]
    [ApiController]
    [Authorize]
    public class AdminsController : ControllerBase
    {
        private IAdminService _adminService;

        public AdminsController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var result = _adminService.Get();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var result = _adminService.Get(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<Action> Create(Admin admin)
        {
            var result = _adminService.Create(admin);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update(Admin admin)
        {
            var result = _adminService.Update(admin);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _adminService.DeleteOne(id);

            if (result == null) return NotFound();
            return Ok(result);

        }
    }
}
