using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace HouseholdManager.Models.Communications
{
    public class TextNotifications
    {
        static void Main(string[] args)
        {
            var accountSid = "ACe21179afce61fd2dbbb88d3088095d85";
            var authToken = "dc253aa0f6b5ed980ef32b45a6d988c9";
            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber("+13147170351");
            var from = new PhoneNumber("+19288822706");

            var message = MessageResource.Create(
                to: to,
                from: from,
                body: "This is a reminder to complete your mission.");

            Console.WriteLine(message.Sid);

        }
    }
}