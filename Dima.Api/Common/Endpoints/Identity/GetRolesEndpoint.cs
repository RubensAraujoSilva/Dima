using Dima.Api.Common.Api;
using System.Security.Claims;
using Dima.Core.Models.Account;

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
                .Select(c => new RoleClaim
                {
                    Issuer = c.Issuer,
                    OriginalIssuer = c.OriginalIssuer,
                    Type = c.Type,
                    Value = c.Value,
                    ValueType = c.ValueType
                });

            return Task.FromResult<IResult>(TypedResults.Json(roles));
        }
    }
}
