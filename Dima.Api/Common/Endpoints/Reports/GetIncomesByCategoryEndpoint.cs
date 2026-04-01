using System.Security.Claims;
using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models.Reports;
using Dima.Core.Requests.Reports;
using Dima.Core.Responses;

namespace Dima.Api.Common.Endpoints.Reports;

public class GetIncomesByCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/incomes", HandleAsync)
            .WithName("Incomes: Entradas por Categoria")
            .WithSummary("Recupera as entradas por categoria")
            .WithDescription("Recupera as entradas por categoria")
            .WithOrder(4)
            .Produces<Response<List<IncomesByCategory>?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        IReportHandler handler)
    {
        var request = new GetIncomesByCategoryRequest
        {
            UserId = user.Identity?.Name ?? string.Empty
        }; 

        var result = await handler.GetIncomesByCategoryReportAsync(request);

        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}