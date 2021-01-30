using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using No.API.Entities;
using No.API.Services.Interfaces;

namespace No.API.Controllers
{
    [AllowAnonymous, Route("v1/[controller]")]
    public class LetterController : ControllerBase
    {
        private readonly ILetterService _letterService;

        public LetterController(ILetterService letterService)
        {
            _letterService = letterService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var data = await _letterService.Get();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message, Inner = ex.InnerException });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Store([FromBody] Letter request)
        {
            try
            {
                var rowsAffected = await _letterService.Store(request);

                return Ok(new { Success = (rowsAffected > 0) });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message, Inner = ex.InnerException });
            }
        }

        [HttpGet("today")]
        public async Task<IActionResult> Today()
        {
            try
            {
                var data = await _letterService.Today();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message, Inner = ex.InnerException });
            }
        }
    }
}