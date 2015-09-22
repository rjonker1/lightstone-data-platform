using System;
using System.Net.Mail;
using Common.Logging;
using Lim.Domain.Base;
using Lim.Domain.Commands;
using Lim.Infrastructure;
using Toolbox.Emailing.Domain;
using Toolbox.Emailing.Infrastructure;

namespace Toolbox.Bmw.Notify
{
    public class FileNotificationFactory : AbstractNotificationFactory<NotifyFile>
    {
        private static readonly ILog Log = LogManager.GetLogger<FileNotificationFactory>();

        private static readonly string From = ConfigurationReader.Bmw.EmailFrom;
        private static readonly string To = ConfigurationReader.Bmw.EmailTo;
        private static readonly string Subject = ConfigurationReader.Bmw.EmailSubject;
        private static readonly string Cc = ConfigurationReader.Bmw.EmailCc;
        private static readonly string Template = ConfigurationReader.Bmw.EmailNotificationTemplate;

        private readonly IDispatchMail<MailMessage> _mailer;
        private readonly IBuildMessage<EmailMessage, MailMessage> _builder;

        public FileNotificationFactory(IDispatchMail<MailMessage> mailer, IBuildMessage<EmailMessage, MailMessage> builder)
        {
            _mailer = mailer;
            _builder = builder;
        }

        public override void Notify(NotifyFile message)
        {
            try
            {
                var letter =
                    _builder.Build(new EmailMessage(Cc, "", To, string.Format("{0} - {1}", Subject, message.Status.ToString().ToUpper()),
                        string.Format(Template, message.Notification), From));
                _mailer.Send(letter);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("An error occurred sending a BMW file notification because of {0}", ex, ex.Message);
            }
        }
    }
}
