using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;

namespace Dima.Api.Common.Endpoints.Transaction
{
    public class GetByIdTransactionEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
          => app.MapGet("/{id:long}", HandleAsync)
                  .WithName("Transactions: Get By Id")
                  .WithSummary("Recupera uma transação pelo id")
                  .WithDescription("Recupera uma transação pelo id")
                  .WithOrder(4)
                  .Produces<Response<Core.Models.Transaction?>>();

        public static async Task<IResult> HandleAsync(
            long id,
            ITransactionHandler handler)
        {
            var request = new GetByIdTransactionRequest
            {
                UserId = "rubens@octosoft.com.br",
                Id = id
            };

            var result = await handler.GetByIdAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
