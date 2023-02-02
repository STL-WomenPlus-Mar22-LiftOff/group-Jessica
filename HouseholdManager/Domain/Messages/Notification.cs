using System;
using System.Text;
using HouseholdManager.Domain.Twilio;
using HouseholdManager.Models;

namespace HouseholdManager.Domain.Messages;

public class Notification
{
    public string? To { get; set; }
    public string? Message { get; set; }


    public static Notification BuildHostNotification(Send send)
    {
        var message = new StringBuilder();
        message.AppendFormat("You have a message {0} for {1}:{2}",
            send.Name,
            send.MessageProperty.Description,
            Environment.NewLine);
        message.AppendFormat("{0}{1}",
            send.Message,
            Environment.NewLine);
        message.Append("Reply [accept] or [reject]");

        return new Notification
        {
            To = send.PhoneNumber,
            Message = message.ToString()
        };
    }

    public static Notification BuildGuestNotification(Send send)
    {
        var message = new StringBuilder();
        message.AppendFormat("Your reservation request to stay at {0} was {1} by the host.",
            send.MessageProperty.Description,
            send.Status == MessageStatus.Confirmed ? "ACCEPTED" : "REJECTED");

        return new Notification
        {
            To = send.PhoneNumber,
            Message = message.ToString()
        };
    }
}