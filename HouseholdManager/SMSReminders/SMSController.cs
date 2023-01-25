using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.TwiML;
using Twilio.AspNet.Mvc;

namespace HouseholdManager.SMSReminders
{
    public class SMSController : TwilioController
    {
        public ActionResult SendSms()
        {
            var accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
            var authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");
            TwilioClient.Init(accountSid, authToken);


            /*var message = MessageResource.Create(
                messagingServiceSid: "MGXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
                body: "Don't forget to complete your message.",
                sendAt: new DateTime(2021, 11, 30, 20, 36, 27),
                scheduleType: MessageResource.ScheduleTypeEnum.Fixed,
                statusCallback: new Uri("https://webhook.site/xxxxx"),
                to: new Twilio.Types.PhoneNumber("+16362883683")*/

            var message = MessageResource.Create(
            from: new Twilio.Types.PhoneNumber("+19288822706"),
            body: "Hi there",
            to: new Twilio.Types.PhoneNumber("+16362883683")
            );

            Console.WriteLine(message.Sid);
        }
    }
    }
}
