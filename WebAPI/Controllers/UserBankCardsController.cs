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
    public class UserBankCardsController : ControllerBase
    {
        IUserBankCardService _userBankCardService;

        public UserBankCardsController(IUserBankCardService userBankCardService)
        {
            _userBankCardService = userBankCardService;
        }

        [HttpGet("get")]
        public IActionResult GetUserBankCardByUserId(int userId)
        {
            var result = _userBankCardService.GetUserBankCardsByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(UserBankCard userBankCardService)
        {
            var result = _userBankCardService.Add(userBankCardService);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(UserBankCard userBankCardService)
        {
            var result = _userBankCardService.Update(userBankCardService);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(UserBankCard userBankCardService)
        {
            var result = _userBankCardService.Delete(userBankCardService);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
