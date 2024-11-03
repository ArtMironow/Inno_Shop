using Inno_Shop.IdentityService.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Inno_Shop.IdentityService.Infrastructure.Persistence;

public class IdentityServiceDbContext : IdentityDbContext<User>
{
	public IdentityServiceDbContext(DbContextOptions<IdentityServiceDbContext> options)
		: base(options)
	{
		Database.EnsureCreated();
		//Database.Migrate();
	}
}