namespace Inno_Shop.IdentityService.Contracts.UserActions.UpdateUser;

public record UpdateUserResponse(Guid Id, string FirstName, string LastName, string Token);