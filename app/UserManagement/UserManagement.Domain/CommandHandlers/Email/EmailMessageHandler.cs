using System;
using System.Net.Mail;
using AutoMapper;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Entities.Commands.Email;

namespace UserManagement.Domain.CommandHandlers.Email
{
    public class EmailMessageHandler : AbstractMessageHandler<EmailMessage>
    {
        public override void Handle(EmailMessage command)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Send(Mapper.Map<EmailMessage, MailMessage>(command));
                }
                catch (SmtpException exception)
                {
                    this.Error(() => "Error sending password reset mail to {0}".FormatWith(string.Join(",", command.ToAddresses), exception));
                    throw new LightstoneAutoException("Error sending password reset mail");
                }
                catch (Exception exception)
                {
                    this.Error(() => "Error sending password reset mail to {0}".FormatWith(string.Join(",", command.ToAddresses), exception));
                    throw new LightstoneAutoException("Error sending password reset mail");
                }
            }
        }
    }
}