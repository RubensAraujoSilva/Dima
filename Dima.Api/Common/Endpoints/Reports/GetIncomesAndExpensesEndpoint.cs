using System.Security.Claims;
using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models.Reports;
using Dima.Core.Requests.Reports;
using Dima.Core.Responses;

namespace Dima.Api.Common.Endpoints.Reports;

public class GetIncomesAndExpensesEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/incomes-expenses", HandleAsync)
            .WithName("IncomesAndExpenses: Entardas e Saídas")
            .WithSummary("Recupera as entradas e saídas")
            .WithDescription("Recupera as entradas e saídas")
            .WithOrder(3)
            .Produces<Response<List<IncomesAndExpenses>?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        IReportHandler handler)
    {
        var request = new GetIncomesAndExpensesRequest
        {
            UserId = user.Identity?.Name ?? string.Empty
        }; 
        
        var result = await handler.GetIncomesAndExpensesReportAsync(request);
       
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}