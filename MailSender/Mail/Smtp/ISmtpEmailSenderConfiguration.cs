namespace MailSender.Mail.Smtp
{
    /// <summary>
    /// Defines configurations to used by SmtpClient object.
    /// </summary>
    public interface ISmtpEmailSenderConfiguration : IEmailSenderConfiguration
    {
        string Host { get; }

        int Port { get; }

        string UserName { get; }

        string Password { get; }

        string Domain { get; }

        bool EnableSsl { get; }

        bool UseDefaultCredentials { get; }
    }
}
