using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;
using System.Security.Claims;

namespace Dima.Api.Common.Endpoints.Transaction
{
    public class DeleteTransactionEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapDelete("/{id:long}", HandleAsync)
                  .WithName("Transaction: Delete")
                  .WithSummary("Exclui uma transação")
                  .WithDescription("Exclui uma transação")
                  .WithOrder(3)
                  .Produces<Response<Dima.Core.Models.Transaction?>>();

        public static async Task<IResult> HandleAsync(
            long id,
            ClaimsPrincipal user,
            ITransactionHandler handler)
        {
            var request = new DeleteTransactionRequest
            {
                UserId =  user.Identity?.Name ?? string.Empty,
                Id = id
            };

            var result = await handler.DeleteAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
