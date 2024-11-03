using Inno_Shop.IdentityService.Application.UserFunctionality.Commands.DeleteUser;
using Inno_Shop.IdentityService.Application.UserFunctionality.Queries.GetUser;
using Inno_Shop.IdentityService.Contracts.UserActions.DeleteUser;
using Inno_Shop.IdentityService.Contracts.UserActions.GetUser;
using Inno_Shop.IdentityService.Domain.Entities;
using Mapster;

namespace Inno_Shop.IdentityService.Api.Common.Mapping;

public class UserMappingConfig : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<GetUserRequest, GetUserQuery>();
		config.NewConfig<User, GetUserResponse>();

		config.NewConfig<DeleteUserResult, DeleteUserResponse>();
	}
}