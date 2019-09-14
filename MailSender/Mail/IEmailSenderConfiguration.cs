namespace MailSender.Mail
{
    public interface IEmailSenderConfiguration
    {
        string DefaultFromAddress { get; }

        string DefaultFromDisplayName { get; }
    }
}
