using Microsoft.Build.Construction;
using Twilio.Clients;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
//using System.Environment;


namespace HouseholdManager.Mission_Reminders
{
    public class RestClient
    {
        private readonly ITwilioRestClient _client;
        string accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
        string authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");
        string twilioNumber = Environment.GetEnvironmentVariable["TWILIO_PHONE_NUMBER"];

        public RestClient()
        {
            _client = new TwilioRestClient(accountSid, authToken,twilioNumber);
        }

        public RestClient(ITwilioRestClient client)
        {
            _client = client;
        }

        public void SendSmsMessage(string phoneNumber, string message)
        {
            var to = new PhoneNumber(phoneNumber);
            MessageResource.Create(
                to,
                from: new PhoneNumber(twilioNumber),
                body: message,
                client: _client);
        }
    }
}
