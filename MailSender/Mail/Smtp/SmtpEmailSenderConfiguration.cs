namespace MailSender.Mail.Smtp
{
    public class SmtpEmailSenderConfiguration : EmailSenderConfiguration, ISmtpEmailSenderConfiguration
    {
        public virtual string Domain
        {
            get { return EmailSettingNames.Smtp.Domain; }
        }

        public virtual bool EnableSsl
        {
            get
            {
                bool b;
                return bool.TryParse(EmailSettingNames.Smtp.EnableSsl, out b);
            }
        }

        public virtual string Host
        {
            get { return GetNotEmptySettingValue(EmailSettingNames.Smtp.Host); }
        }

        public virtual string Password
        {
            get { return GetNotEmptySettingValue(EmailSettingNames.Smtp.Password); }
        }

        public virtual int Port
        {
            get
            {
                int i;
                return !int.TryParse(EmailSettingNames.Smtp.Port, out i) ? 0 : i;
            }
        }

        public virtual bool UseDefaultCredentials
        {
            get
            {
                bool b;
                return bool.TryParse(EmailSettingNames.Smtp.UseDefaultCredentials, out b);
            }
        }

        public virtual string UserName
        {
            get { return GetNotEmptySettingValue(EmailSettingNames.Smtp.UserName); }
        }

    }
}
