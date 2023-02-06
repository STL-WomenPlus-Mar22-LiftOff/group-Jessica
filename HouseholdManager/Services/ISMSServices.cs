
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio.Rest.Api.V2010.Account;

namespace HouseholdManager.Services
{
    public interface ISMSServices
    {
        MessageResource messageResource(string PhoneNumber, string Message);
    }
}
