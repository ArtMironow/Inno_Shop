using Inno_Shop.IdentityService.Application.Services.EmailService;

namespace Inno_Shop.IdentityService.Application.Common.Interfaces.Services;

public interface IEmailSender
{
	void SendEmail(Message message);
	Task SendEmailAsync(Message message);
}