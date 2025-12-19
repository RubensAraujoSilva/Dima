using Dima.Api.Data;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace Dima.Api.Handlers
{
    public class CategoryHandler(AppDbContext context) : ICategoryHandler
    {
        public async Task<Response<Category?>> CreateAsync(CreateCategoryRequest request)
        {
            try
            {

                var category = new Category
                {
                    UserId = request.UserId,
                    Title = request.Title,
                    Description = request.Description
                };

                await context.Categories.AddAsync(category);
                await context.SaveChangesAsync();

                return new Response<Category?>(category, 201, "Categoria criada com sucesso");

            }
            catch
            {
                return new Response<Category?>(null, 500, "Não foi possível criar a categoria");
            }
        }
        public async Task<Response<Category?>> UpdateAsync(UpdateCategoryRequest request)
        {
            try
            {

                var category = await context
                                .Categories
                                .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                if (category is null)
                    return new Response<Category?>(null, 404, "Categoria não encontrada");

                //TODO - Refatorar com Automapper
                category.Title = request.Title;
                category.Description = request.Description;

                context.Categories.Update(category);
                await context.SaveChangesAsync();

                return new Response<Category?>(category, 200, "Categoria atualizada com sucesso");

            }
            catch
            {
                return new Response<Category?>(null, 500, "Não foi possível atualizar a categoria");
            }
        }
        public async Task<Response<Category?>> DeleteAsync(DeleteCategoryRequest request)
        {
            try
            {

                var category = await context
                                .Categories
                                .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                if (category is null)
                    return new Response<Category?>(null, 404, "Categoria não encontrada");

                context.Categories.Remove(category);
                await context.SaveChangesAsync();

                return new Response<Category?>(category, message: "Categoria excluída com sucesso");

            }
            catch
            {
                return new Response<Category?>(null, 500, "Não foi possível excluir a categoria");
            }
        }
        public async Task<Response<Category?>> GetByIdAsync(GetByIdCategoryRequest request)
        {
            try
            {

                var category = await context
                                .Categories
                                .AsNoTrackingWithIdentityResolution()
                                .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                return category is null
                    ? new Response<Category?>(null, 404, "Categoria não encontrada")
                    : new Response<Category?>(category, message: "Categoria recuperada com sucesso");

            }
            catch
            {
                return new Response<Category?>(null, 500, "Não foi possível recuperar a categoria");
            }
        }
        public async Task<PagedResponse<List<Category>>> GetAllAsync(GetAllCategoriesRequest request)
        {
            try
            {

                var query = context.Categories
                                   .AsNoTrackingWithIdentityResolution()
                                   .Where(x => x.UserId == request.UserId)
                                   .OrderBy(x => x.Title);

                var categories = await query.Skip((request.PageNumber - 1) * request.PageSize)
                                            .Take(request.PageSize)
                                            .ToListAsync();

                var count = await query.CountAsync();
                 
                return categories is null
                    ? new PagedResponse<List<Category>>(null, 404, "Categorias não encontrada")
                    : new PagedResponse<List<Category>>(categories, count, request.PageNumber, request.PageSize);

            }
            catch
            {
                return new PagedResponse<List<Category>>(null, 500, "Não foi possível recuperar as categorias");
            }
        }

    }
}
