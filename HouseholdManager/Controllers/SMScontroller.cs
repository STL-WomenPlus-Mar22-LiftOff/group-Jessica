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
            var accountSID = "ACe21179afce61fd2dbbb88d3088095d85";
            var authtoken = "8b1ec11baeebac35ec5506db4df79bea";
            TwilioClient.Init(accountSID, authtoken);

            var to = new PhoneNumber("+16362883683");
            var from = new PhoneNumber("+19288822706");

            var message = MessageResource.Create(
                to: to,
                from: from,
                body: "Don't forget to complete your mission"!);

            return (IActionResult)Content(message.Sid);

        }

        public TwiMLResult Index(SmsRequest incomingMessage)
        {
            var messagingResponse = new MessagingResponse();
            messagingResponse.Message("The copy cat says: " +
                                      incomingMessage.Body);

            return TwiML(messagingResponse);

        }
}
