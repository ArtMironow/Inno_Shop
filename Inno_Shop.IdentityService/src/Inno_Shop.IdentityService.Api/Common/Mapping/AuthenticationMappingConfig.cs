using Inno_Shop.IdentityService.Application.Authentication.Commands.Register;
using Inno_Shop.IdentityService.Application.Authentication.Common;
using Inno_Shop.IdentityService.Application.Authentication.Queries.Login;
using Inno_Shop.IdentityService.Contracts.Authentication;
using Mapster;

namespace Inno_Shop.IdentityService.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<RegisterRequest, RegisterCommand>();

		config.NewConfig<LoginRequest, LoginQuery>();

		config.NewConfig<AuthenticationResult, AuthenticationResponse>()
			.Map(dest => dest, src => src.User);
	}
}