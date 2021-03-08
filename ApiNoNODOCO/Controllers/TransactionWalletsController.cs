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
    [Route("api/v1/transactionWallets")]
    [ApiController]
    public class TransactionWalletsController : ControllerBase
    {
        private ITransactionWalletService _transactionWalletService;

        public TransactionWalletsController(ITransactionWalletService transactionWalletService)
        {
            _transactionWalletService = transactionWalletService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var result = _transactionWalletService.Get();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var result = _transactionWalletService.Get(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<Action> Create(TransactionWallet transactionWallet)
        {
            var result = _transactionWalletService.Create(transactionWallet);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update(TransactionWallet transactionWallet)
        {
            var result = _transactionWalletService.Update(transactionWallet);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _transactionWalletService.DeleteOne(id);

            if (result == null) return NotFound();
            return Ok(result);

        }
    }
}
