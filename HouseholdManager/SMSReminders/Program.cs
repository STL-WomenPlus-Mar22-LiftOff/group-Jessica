namespace HouseholdManager.SMSReminders;
// Install the C# / .NET helper library from twilio.com/docs/csharp/install

using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;


class Program
{
    static void Main(string[] args)
    {
        // Find your Account SID and Auth Token at twilio.com/console
        // and set the environment variables. See http://twil.io/secure
        var accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
        var authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");

        TwilioClient.Init(accountSid, authToken);

    var message = MessageResource.Create(
        messagingServiceSid: "MG0dd465e7598684d4a56ab72bf39eb724",
        body: "Don't forget to complete your mission!",
        sendAt: new DateTime(2021, 11, 30, 20, 36, 27),
        scheduleType: MessageResource.ScheduleTypeEnum.Fixed,
        statusCallback: new Uri("https://webhook.site/xxxxx"),
        to: new Twilio.Types.PhoneNumber("+16362883683")
    /*body: "Join Earth's mightiest heroes. Like Kevin Bacon.",
            from: new Twilio.Types.PhoneNumber("+19288822706"),
            to: new Twilio.Types.PhoneNumber("+6362883683")*/
        );

        Console.WriteLine(message.Sid);
    }
}
