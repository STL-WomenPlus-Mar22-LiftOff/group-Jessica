using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HouseholdManager.Data.SendSms;
using HouseholdManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseholdManager.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SMSController : ControllerBase
{
    private readonly ISMSServices _SMSServices;

    public SMSController(ISMSServices smsServices)
    {
        _SMSServices = smsServices;
    }
   
    [HttpPost("send")]
    public IActionResult SendSMS(TransferredData data)
    {
        var result = _SMSServices.messageResource(data.PhoneNumber, data.MessageBody);
        if (!string.IsNullOrEmpty(result.ErrorMessage))
        {
            return BadRequest(result.ErrorMessage);
        }
        return Ok(result);

    }
}
