namespace HouseholdManager.Domain.Twilio

{
    public class TwilioConfiguration
    {
         
        public string AccountSid { get; set; } = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
        public string AuthToken { get; set; } = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");
        public string PhoneNumber { get; set; } = Environment.GetEnvironmentVariable("TWILIO_PHONE_NUMBER");
    }
}
    

