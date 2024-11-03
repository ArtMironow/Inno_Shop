using Inno_Shop.IdentityService.Application.Common.Interfaces.Services;
using MailKit.Net.Smtp;
using MimeKit;

namespace Inno_Shop.IdentityService.Application.Services.EmailService;

public class EmailSender(EmailConfiguration emailConfig) : IEmailSender
{
	private readonly EmailConfiguration _emailConfig = emailConfig;

	public void SendEmail(Message message)
	{
		var emailMessage = CreateEmailMessage(message);

		Send(emailMessage);
	}

	public async Task SendEmailAsync(Message message)
	{
		var emailMessage = CreateEmailMessage(message);

		await SendAsync(emailMessage);
	}

	private MimeMessage CreateEmailMessage(Message message)
	{
		var emailMessage = new MimeMessage();

		emailMessage.From.Add(new MailboxAddress("email", _emailConfig.From));
		emailMessage.To.AddRange(message.To);
		emailMessage.Subject = message.Subject;

		var bodyBuilder = new BodyBuilder { HtmlBody = string.Format("<h2 style='color:red;'>{0}</h2>", message.Content) };

		if (message.Attachments != null && message.Attachments.Any())
		{
			byte[] fileBytes;
			foreach (var attachment in message.Attachments)
			{
				using (var ms = new MemoryStream())
				{
					attachment.CopyTo(ms);
					fileBytes = ms.ToArray();
				}

				bodyBuilder.Attachments.Add(attachment.FileName, fileBytes, ContentType.Parse(attachment.ContentType));
			}
		}

		emailMessage.Body = bodyBuilder.ToMessageBody();
		return emailMessage;
	}

	private void Send(MimeMessage emailMessage)
	{
		var client = new SmtpClient();
		try
		{
			client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
			client.AuthenticationMechanisms.Remove("XOAUTH2");
			client.Authenticate(_emailConfig.UserName, _emailConfig.Password);

			client.Send(emailMessage);
		}
		catch
		{
			throw;
		}
		finally
		{
			client.Disconnect(true);
			client.Dispose();
		}
	}

	private async Task SendAsync(MimeMessage emailMessage)
	{
		var client = new SmtpClient();
		try
		{
			await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, true);
			client.AuthenticationMechanisms.Remove("XOAUTH2");
			await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);
			await client.SendAsync(emailMessage);
		}
		catch
		{
			throw;
		}
		finally
		{
			await client.DisconnectAsync(true);
			client.Dispose();
		}
	}
}