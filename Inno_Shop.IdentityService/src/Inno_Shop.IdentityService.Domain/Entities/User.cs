using Microsoft.AspNetCore.Identity;

namespace Inno_Shop.IdentityService.Domain.Entities;

public class User : IdentityUser
{
	public string FirstName { get; set; } = null!;
	public string LastName { get; set; } = null!;
}