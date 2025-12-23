using Dima.Api.Common.Api;
using Dima.Api.Models;
using Dima.Core;
using Dima.Core.Handlers;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dima.Api.Common.Endpoints.Transaction
{
    public class GetByPeriodTransactionEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
         => app.MapGet("/", HandleAsync)
                  .WithName("Transactions: Get by period")
                  .WithSummary("Recupera todas as transações por um periodo")
                  .WithDescription("Recupera todas as transações por um periodo")
                  .WithOrder(5)
                  .Produces<PagedResponse<List<Core.Models.Transaction?>>>();

        public static async Task<IResult> HandleAsync(
            ITransactionHandler handler,
            ClaimsPrincipal user,
            [FromQuery] DateTime? startDate = null, 
            [FromQuery] DateTime? endDate = null, 
            [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
            [FromQuery] int pageSize = Configuration.DefaultPageSize)
        {
            var request = new GetByPeriodTransactionRequest
            {
                StartDate = startDate,
                EndtDate = endDate,
                UserId = user.Identity?.Name ?? string.Empty,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var result = await handler.GetByPeriodAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
