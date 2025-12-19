using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;

namespace Dima.Api.Common.Endpoints.Transaction
{
    public class UpdateTransactionEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id:long}", HandleAsync)
              .WithName("Transactions: Update")
              .WithSummary("Atualiza uma transação")
              .WithDescription("Atualiza uma transação")
              .WithOrder(2)
              .Produces<Response<Core.Models.Transaction?>>();

        private static async Task<IResult> HandleAsync(
            long id,
            ITransactionHandler handler,
            UpdateTransactionRequest request)
        {
            request.UserId = "rubens@octosoft.com.br";
            request.Id = id;

            var result = await handler.UpdateAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
