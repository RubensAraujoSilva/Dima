using Dima.Api.Common.Api;
using Dima.Api.Common.Endpoints.Categories;
using Dima.Api.Common.Endpoints.Transaction;
using Dima.Api.Common.Endpoints.Transactions;

namespace Dima.Api.Common.Endpoints
{
    public static class Endpoint
    {
        //Estension method to map all endpoints
        public static void MapEndpoints(this WebApplication app)
        {
            var endpoints = app.MapGroup("");

            endpoints.MapGroup("/v1/categories")
                     .WithTags("Categories")
                     //.RequireAuthorization()
                     .MapEndpoint<CreateCategoryEndpoint>()
                     .MapEndpoint<UpdateCategoryEndpoint>()
                     .MapEndpoint<DeleteCategoryEndpoint>()
                     .MapEndpoint<GetByIdCategoryEndpoint>()
                     .MapEndpoint<GetAllCategoryEndpoint>();

            endpoints.MapGroup("/v1/transactions")
                    .WithTags("Transactions")
                    //.RequireAuthorization()
                    .MapEndpoint<CreateTransactionEndpoint>()
                    .MapEndpoint<UpdateTransactionEndpoint>()
                    .MapEndpoint<DeleteTransactionEndpoint>()
                    .MapEndpoint<GetByIdTransactionEndpoint>()
                    .MapEndpoint<GetByPeriodTransactionEndpoint>();
        }

        private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
            where TEndpoint : IEndpoint
        {
            TEndpoint.Map(app);
            return app;
        }
    }
}
