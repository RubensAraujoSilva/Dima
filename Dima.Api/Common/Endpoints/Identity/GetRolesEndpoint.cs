using Dima.Api.Common.Api;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Dima.Api.Common.Endpoints.Identity
{
    public class GetRolesEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/roles", Handle)
                  .WithName("Identity: Roles")
                  .WithSummary("Listar roles do usuário")
                  .WithDescription("Listar roles do usuário")
                  .RequireAuthorization();

        private static Task<IResult> Handle(ClaimsPrincipal user)
        {
            if (user.Identity is null || !user.Identity.IsAuthenticated)
                return Task.FromResult(Results.Unauthorized());

            var idendity = (ClaimsIdentity)user.Identity;
            var roles = idendity
                .FindAll(idendity.RoleClaimType)
                .Select(c => new
                {
                    c.Issuer,
                    c.OriginalIssuer,
                    c.Type,
                    c.Value,
                    c.ValueType
                });

            return Task.FromResult<IResult>(TypedResults.Json(roles));
        }
    }
}
