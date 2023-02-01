using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace HouseholdManager.SMSReminders
{
    public class Cancel

    {
        static void Main(string[] args)
        {
            // Find your Account Sid and Auth Token at twilio.com/console
            // To set up environmental variables, see http://twil.io/secure
            var accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
            var authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");
            TwilioClient.Init(accountSid, authToken);

            const string sid = "MG0dd465e7598684d4a56ab72bf39eb724";
            var message = MessageResource.Update(sid, "");

            Console.WriteLine(message.Body); // will be empty
        }
    }
}