using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using HouseholdManager.Controllers;

namespace HouseholdManager.Models
{
    public class SMS
    {
        public string sendSms {get; set;}

        public string receiveSms { get; set;}
    }
}
