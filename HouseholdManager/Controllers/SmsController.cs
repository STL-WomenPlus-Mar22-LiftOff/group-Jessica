using HouseholdManager.Domain.Messages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Twilio.TwiML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouseholdManager.Data;
using HouseholdManager.Models;
using Microsoft.EntityFrameworkCore;
using Twilio;
using Twilio.TwiML.Voice;
using HouseholdManager.Models.Repositories;

namespace HouseholdManager.Controllers
{
    public class SmsController : TwilioController
    {
        private readonly Models.Repositories.IApplicationDbRepository _repository;
        private readonly INotifier _notifier;
        private Notification notification;

        public SmsController(
            IApplicationDbRepository repository,
            INotifier notifier)
        {
            _repository = repository;
            _notifier = notifier;
        }


        // POST Sms/Handle
        [HttpPost]
        [AllowAnonymous]
        public async Task<TwiMLResult> Handle(string from, string body)
        {
            string smsResponse;

            try
            {
                var host = await _repository.FindUserByPhoneNumberAsync(from);
                var send = await _repository.FindFirstPendingSendByHostAsync(host.Id);

                var smsRequest = body;
                send.Status =
                    smsRequest.Equals("accept", StringComparison.InvariantCultureIgnoreCase) ||
                    smsRequest.Equals("yes", StringComparison.InvariantCultureIgnoreCase)
                        ? MessageStatus.Confirmed
                        : MessageStatus.Rejected;

                await _repository.UpdateSendAsync(send);
                smsResponse = $"You have successfully {send.Status} the message";

                // Notify guest with host response
                var notification = Notification.BuildGuestNotification(send);

                await _notifier.SendNotificationAsync(notification);
            }
            catch (InvalidOperationException)
            {
                smsResponse = "Sorry, it looks like you don't have any messages.";
            }
            catch (Exception)
            {
                smsResponse = "Sorry, it looks like we get an error. Try later!";
            }

            return TwiML(Respond(smsResponse));
        }

        private TwiMLResult TwiML(MessagingResponse messagingResponse)
        {
            throw new NotImplementedException();
        }

        private static MessagingResponse Respond(string message)
        {
            var response = new MessagingResponse();
            response.Message(message);

            return response;
        }

    }
}