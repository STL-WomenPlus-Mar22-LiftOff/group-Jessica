using Microsoft.Build.Construction;
using Twilio.Clients;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;


namespace HouseholdManager.Mission_Reminders
{
    public class RestClient
    {
        private readonly ITwilioRestClient _client;
        private readonly string _accountSid = ConfigurationSettings.AppSettings["AccountSid"];
        private readonly string _authToken = ConfigurationSettings.AppSettings["AuthToken"];
        private readonly string _twilioNumber = ConfigurationSettings.AppSettings["TwilioNumber"];

        public RestClient()
        {
            _client = new TwilioRestClient(_accountSid, _authToken);
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
                from: new PhoneNumber(_twilioNumber),
                body: message,
                client: _client);
        }
    }
}
