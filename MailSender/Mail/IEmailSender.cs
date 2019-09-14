using System.Net.Mail;
using System.Threading.Tasks;

namespace MailSender.Mail
{
    public interface IEmailSender
    {
        Task SendAsync(string to, string subject, string body, bool isBodyHtml = true);

        void Send(string to, string subject, string body, bool isBodyHtml = true);

        Task SendAsync(string from, string to, string subject, string body, bool isBodyHtml = true);

        void Send(string from, string to, string subject, string body, bool isBodyHtml = true);

        /// <summary>
        /// Sends an email
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="normalize">
        /// Should normalize email
        /// If true, it sets sender address/name if it's not set before and makes mail encoding UTF-8
        /// </param>
        void Send(MailMessage mail, bool normalize = true);

        /// <summary>
        /// Sends an email
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="normalize">
        /// Should normalize email
        /// If true, it sets sender address/name if it's not set before and makes mail encoding UTF-8
        /// </param>
        Task SendAsync(MailMessage mail, bool normalize = true);
    }
}
