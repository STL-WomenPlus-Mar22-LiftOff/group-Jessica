using Microsoft.AspNetCore.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.TwiML;
using Twilio.Http;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Twilio.AspNet.Common;
using Twilio.AspNet.Core;

namespace HouseholdManager.Controllers
{
    public class SMScontroller : TwilioController
    {
        //get sms
        public IActionResult SendSms()
        {
            var accountSID = "accountSID";
            var authtoken = "authtoken";
            TwilioClient.Init(accountSID, authtoken);

            var to = new PhoneNumber("+18888888888");
            var from = new PhoneNumber("Twilio phone number");

            var message = MessageResource.Create(
                to: to,
                from: from,
                body: "Don't forget to complete your mission!");

            return (IActionResult)Content(message.Sid);

        }

        public TwiMLResult ReceiveSms ()
        {
            var response = new MessagingResponse();
            response.Message("Get to work!");

            return TwiML(response);

        }
    }
}
