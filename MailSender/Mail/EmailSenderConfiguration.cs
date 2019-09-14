using System;

namespace MailSender.Mail
{
    public class EmailSenderConfiguration : IEmailSenderConfiguration
    {
        public virtual string DefaultFromAddress
        {
            get { return GetNotEmptySettingValue(EmailSettingNames.DefaultFromAddress); }
        }

        public virtual string DefaultFromDisplayName
        {
            get { return EmailSettingNames.DefaultFromDisplayName; }
        }

        protected string GetNotEmptySettingValue(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception($"Setting value for '{name}' is null or empty!");
            }
            return name;
        }
    }
}