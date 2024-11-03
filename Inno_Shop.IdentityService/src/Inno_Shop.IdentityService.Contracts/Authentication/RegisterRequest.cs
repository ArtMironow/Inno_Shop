namespace Inno_Shop.IdentityService.Contracts.Authentication;
public record RegisterRequest(string FirstName, string LastName, string Email, string Password);
