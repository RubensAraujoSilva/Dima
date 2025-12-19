using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;

namespace Dima.Api.Common.Endpoints.Categories
{
    public class DeleteCategoryEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapDelete("/{id:long}", HandleAsync)
                  .WithName("Transactions: Delete")
                  .WithSummary("Exclui uma transação")
                  .WithDescription("Exclui uma transação")
                  .WithOrder(3)
                  .Produces<Response<Category?>>();

        public static async Task<IResult> HandleAsync(
            long id,
            ITransactionHandler handler)
        {
            var request = new DeleteTransactionRequest 
            {
                UserId = "rubens@octosoft.com.br",
                Id = id
            };

            var result = await handler.DeleteAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
