using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MockSmsProvider.Models.DTOs;
using MockSmsProvider.Services.Interfaces;

namespace MockSmsProvider.Controllers
{
    /// <summary>
    /// Api cotroller for sms related actions
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController(ISmsService smsService) : ControllerBase
    {
        private ISmsService _smsService = smsService;

        /// <summary>
        /// Api endpoint for sending sms for another user
        /// </summary>
        /// <param name="sendSmsDto">DTO for sending message. Includes: id of sender, id of receiver and the message itself.</param>
        /// <returns>Returns SendSmsResultDto DTO which continas a boolean value indication success and a error message if needed.</returns>
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
