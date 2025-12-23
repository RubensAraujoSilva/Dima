using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;
using System.Security.Claims;

namespace Dima.Api.Common.Endpoints.Categories
{
    public class GetByIdCategoryEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
          => app.MapGet("/{id:long}", HandleAsync)
                  .WithName("Categories: Get By Id")
                  .WithSummary("Recupera uma categoria pelo id")
                  .WithDescription("Recupera uma categoria pelo id")
                  .WithOrder(4)
                  .Produces<Response<Category?>>();

        public static async Task<IResult> HandleAsync(
            long id,
            ClaimsPrincipal user,
            ICategoryHandler handler)
        {
            var request = new GetByIdCategoryRequest
            {
                UserId = user.Identity?.Name ?? string.Empty,
                Id = id
            };

            var result = await handler.GetByIdAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
