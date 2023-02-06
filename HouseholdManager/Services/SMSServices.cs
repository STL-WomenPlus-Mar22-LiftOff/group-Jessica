using Twilio;
using Microsoft.Extensions.Options;
using HouseholdManager.Twilio_Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio.Rest.Api.V2010.Account;

namespace HouseholdManager.Services
{
    public class SMSServices : ISMSServices
    {
        private readonly TwilioSettings _TwilioSettings;

        public SMSServices(IOptions<TwilioSettings> twilioSettings)
        {
            _TwilioSettings = twilioSettings.Value;
        }

        public MessageResource messageResource(string PhoneNumber, string Message)
        {
            TwilioClient.Init(_TwilioSettings.AccountSID, _TwilioSettings.AuthToken);
            var message = MessageResource.Create(
                body: Message,
                from: new Twilio.Types.PhoneNumber(_TwilioSettings.TwilioPhoneNumber),
                to: PhoneNumber
                );
            return message;
        }
    }
}
