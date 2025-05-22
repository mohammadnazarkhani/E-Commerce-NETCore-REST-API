using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MockSmsProvider.Models.DTOs;
using MockSmsProvider.Services.Interfaces;

namespace MockSmsProvider.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : ControllerBase
    {
        private ISmsService _smsService;

        public SmsController(ISmsService smsService)
        {
            _smsService = smsService;
        }

        [HttpPost]
        public async Task<ActionResult<SendSmsResultDto>> SendSms([FromBody] SendSmsDto sendSmsDto)
        {
            var result = await _smsService.SendSms(sendSmsDto.Sender, sendSmsDto.Receiver, sendSmsDto.Message);
            var resultDto = new SendSmsResultDto()
            {
                Success = result
            };

            if (result)
                return Ok(resultDto);

            resultDto.ErrorMessage = "User not found. Please enter a valid user id.";
            return BadRequest(resultDto);
        }
    }
}
