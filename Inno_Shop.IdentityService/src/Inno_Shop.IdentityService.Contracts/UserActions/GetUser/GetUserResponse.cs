namespace Inno_Shop.IdentityService.Contracts.UserActions.GetUser;
public record GetUserResponse(Guid Id, string FirstName, string LastName, string Email);