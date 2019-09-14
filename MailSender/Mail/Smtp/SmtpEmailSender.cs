using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MailSender.Mail.Smtp
{
	/// <summary>
	/// Used to send emails over SMTP
	/// </summary>
	public class SmtpEmailSender : EmailSenderBase, ISmtpEmailSender
	{
		private readonly ISmtpEmailSenderConfiguration Configuration;

		public SmtpEmailSender(ISmtpEmailSenderConfiguration configuration)
			: base(configuration)
		{
			Configuration = configuration;
		}
		public SmtpClient BuildClient()
		{
			var host = Configuration.Host;
			//var port = Configuration.Port;
			var smtpClient = new SmtpClient(host/*, port*/);
			try
			{
				if (Configuration.EnableSsl)
				{
					smtpClient.EnableSsl = true;
				}

				if (Configuration.UseDefaultCredentials)
				{
					smtpClient.UseDefaultCredentials = true;
				}
				else
				{
					smtpClient.UseDefaultCredentials = false;
					var userName = Configuration.UserName;
					if (!string.IsNullOrEmpty(userName))
					{
						var password = Configuration.Password;
						var domain = Configuration.Domain;
						smtpClient.Credentials = !string.IsNullOrEmpty(domain)
							? new NetworkCredential(userName, password, domain)
							: new NetworkCredential(userName, password);
					}
				}
				return smtpClient;
			}
			catch (Exception)
			{
				smtpClient.Dispose();
				throw;
			}
		}

		protected override void SendEmail(MailMessage mail)
		{
			using (var smtpClient = BuildClient())
			{
				smtpClient.Send(mail);
			}
		}

		protected override async Task SendEmailAsync(MailMessage mail)
		{
			using (var smtpClient = BuildClient())
			{
				await smtpClient.SendMailAsync(mail);
			}
		}
	}
}
