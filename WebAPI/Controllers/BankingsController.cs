using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankingsController : ControllerBase
    {
        IBankingService _bankingService;

        public BankingsController(IBankingService bankingService)
        {
            _bankingService = bankingService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _bankingService.GetAllBankings();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Banking banking)
        {
            var result = _bankingService.Add(banking);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
