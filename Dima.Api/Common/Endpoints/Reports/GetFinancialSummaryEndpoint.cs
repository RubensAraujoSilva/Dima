using System.Security.Claims;
using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models.Reports;
using Dima.Core.Requests.Reports;
using Dima.Core.Responses;

namespace Dima.Api.Common.Endpoints.Reports;

public class GetFinancialSummaryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/summary", HandleAsync)
            .WithName("Summary: Resumo Financeiro")
            .WithSummary("Recupera o resumo financerio")
            .WithDescription("Recupera o resumo financerio")
            .WithOrder(2)
            .Produces<Response<FinancialSummary>?>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        IReportHandler handler)
    {
        var request = new GetFinancialSummaryRequest
        {
            UserId = user.Identity?.Name ?? string.Empty
        };
        var result = await handler.GetFinancialSummaryReportAsync(request);

        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}