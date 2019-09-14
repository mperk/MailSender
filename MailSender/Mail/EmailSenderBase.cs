using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Mail
{
    public abstract class EmailSenderBase : IEmailSender
    {
        public IEmailSenderConfiguration Configuration { get; }

        public EmailSenderBase(IEmailSenderConfiguration configuration)
        {
            Configuration = configuration;
        }

        public virtual async Task SendAsync(string to, string subject, string body, bool isBodyHtml = true)
        {
            await SendAsync(new MailMessage
            {
                To = { to },
                Subject = subject,
                Body = body,
                IsBodyHtml = isBodyHtml
            });
        }

        public virtual void Send(string to, string subject, string body, bool isBodyHtml = true)
        {
            Send(new MailMessage
            {
                To = { to },
                Subject = subject,
                Body = body,
                IsBodyHtml = isBodyHtml
            });
        }

        public virtual async Task SendAsync(string from, string to, string subject, string body, bool isBodyHtml = true)
        {
            await SendAsync(new MailMessage(from, to, subject, body) { IsBodyHtml = isBodyHtml });
        }

        public virtual void Send(string from, string to, string subject, string body, bool isBodyHtml = true)
        {
            Send(new MailMessage(from, to, subject, body) { IsBodyHtml = isBodyHtml });
        }

        public virtual async Task SendAsync(MailMessage mail, bool normalize = true)
        {
            if (normalize)
            {
                NormalizeMail(mail);
            }

            await SendEmailAsync(mail);
        }

        public virtual void Send(MailMessage mail, bool normalize = true)
        {
            if (normalize)
            {
                NormalizeMail(mail);
            }

            SendEmail(mail);
        }

        /// <summary>
        /// Should implement this method to send email in derived classes.
        /// </summary>
        /// <param name="mail">Mail to be sent</param>
        protected abstract Task SendEmailAsync(MailMessage mail);

        /// <summary>
        /// Should implement this method to send email in derived classes.
        /// </summary>
        /// <param name="mail">Mail to be sent</param>
        protected abstract void SendEmail(MailMessage mail);

        protected virtual void NormalizeMail(MailMessage mail)
        {
            if(mail.From == null || string.IsNullOrEmpty(mail.From.Address))
            {
                mail.From = new MailAddress(
                    Configuration.DefaultFromAddress, 
                    Configuration.DefaultFromDisplayName, 
                    Encoding.UTF8);
            }

            if(mail.HeadersEncoding == null)
            {
                mail.HeadersEncoding = Encoding.UTF8;
            }

            if(mail.SubjectEncoding == null)
            {
                mail.SubjectEncoding = Encoding.UTF8;
            }

            if(mail.BodyEncoding == null)
            {
                mail.BodyEncoding = Encoding.UTF8;
            }
        }
    }
}