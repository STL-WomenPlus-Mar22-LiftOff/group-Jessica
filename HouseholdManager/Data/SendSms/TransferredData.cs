using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HouseholdManager.Data.SendSms
{
    public class TransferredData
    {
        public string PhoneNumber { get; set; }
        public string MessageBody { get; set; }
    }
}
