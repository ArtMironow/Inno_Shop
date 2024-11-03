namespace Inno_Shop.IdentityService.Contracts.UserActions.UpdateUser;

public record UpdateUserRequest(Guid Id, string FirstName, string LastName);