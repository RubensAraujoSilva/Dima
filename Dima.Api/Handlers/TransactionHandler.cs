using Dima.Api.Data;
using Dima.Core.Common.Extensions;
using Dima.Core.Enums;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace Dima.Api.Handlers
{
    public class TransactionHandler(AppDbContext context) : ITransactionHandler
    {
        public async Task<Response<Transaction?>> CreateAsync(CreateTransactionRequest request)
        {
            try
            {
                if(request is { Type: ETransactionType.Withdraw, Amount: >= 0 })
                    request.Amount *= -1; // Transforma o valor em negativo 
                
                //TODO - Refatorar para Automapper
                var transaction = new Transaction
                {
                    UserId = request.UserId,
                    Title = request.Title,
                    Type = request.Type,
                    Amount = request.Amount,
                    CategoryId = request.CategoryId,
                    PaidOrReceivedAt = request.PaidOrReceivedAt,
                    CreatedAt = DateTime.Now
                };

                await context.Transactions.AddAsync(transaction);
                await context.SaveChangesAsync();

                return new Response<Transaction?>(transaction, 201, "Transação criada com sucesso");

            }
            catch
            {
                return new Response<Transaction?>(null, 500, "Não foi possível criar sua transação");
            }
        }
        public async Task<Response<Transaction?>> UpdateAsync(UpdateTransactionRequest request)
        {
            try
            {
                if(request is { Type: ETransactionType.Withdraw, Amount: >= 0 })
                    request.Amount *= -1; // Transforma o valor em negativo 
                
                var transaction = await context
                                .Transactions
                                .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                if (transaction is null)
                    return new Response<Transaction?>(null, 404, "Transação não encontrada");

                //TODO - Refatorar com Automapper
                transaction.Title = request.Title;
                transaction.Type = request.Type;
                transaction.Amount = request.Amount;
                transaction.CategoryId = request.CategoryId;
                transaction.PaidOrReceivedAt = request.PaidOrReceivedAt;


                context.Transactions.Update(transaction);
                await context.SaveChangesAsync();

                return new Response<Transaction?>(transaction, 200, "Transação atualizada com sucesso");

            }
            catch
            {
                return new Response<Transaction?>(null, 500, "Não foi possível atualizar sua transação");
            }
        }
        public async Task<Response<Transaction?>> DeleteAsync(DeleteTransactionRequest request)
        {
            try
            {

                var transaction = await context
                                .Transactions
                                .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                if (transaction is null)
                    return new Response<Transaction?>(null, 404, "Transação não encontrada");

                context.Transactions.Remove(transaction);
                await context.SaveChangesAsync();

                return new Response<Transaction?>(transaction, 200, "Transação ecluída com sucesso");

            }
            catch
            {
                return new Response<Transaction?>(null, 500, "Não foi possível excluir sua transação");
            }
        }
        public async Task<Response<Transaction?>> GetByIdAsync(GetByIdTransactionRequest request)
        {
            try
            {

                var transaction = await context
                                .Transactions
                                .AsNoTracking()
                                .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                return transaction is null
                    ? new Response<Transaction?>(null, 404, "Transação não encontrada")
                    : new Response<Transaction?>(transaction, message: "Transação recuperada com sucesso");

            }
            catch
            {
                return new Response<Transaction?>(null, 500, "Não foi possível recuperada sua transação");
            }

        }
        public async Task<PagedResponse<List<Transaction>?>> GetByPeriodAsync(GetByPeriodTransactionRequest request)
        {
            try
            {
                // Carrega nossos valores padrão para o período (mês atual)
                request.StartDate ??= DateTime.Now.GetFirstDay();
                request.EndtDate ??= DateTime.Now.GetLastDay();
            }
            catch
            {
                return new PagedResponse<List<Transaction>?>(null, 500, "Não foi possível determinar a data de início e fim");
            }

            try
            {

                var query = context.Transactions
                                 .AsNoTracking()
                                 .Where(x => 
                                    x.UserId == request.UserId && 
                                    x.PaidOrReceivedAt >= request.StartDate && 
                                    x.PaidOrReceivedAt <= request.EndtDate)
                                 .OrderBy(x => x.PaidOrReceivedAt);

                var transaction = await query.Skip((request.PageNumber - 1) * request.PageSize)
                                            .Take(request.PageSize)
                                            .ToListAsync();

                var count = await query.CountAsync();

                return transaction is null
                    ? new PagedResponse<List<Transaction>?>(null, 404, "Não foi possível recuperar as transações")
                    : new PagedResponse<List<Transaction>>(transaction, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Transaction>?>(null, 500, "Não foi possível recuperar as trasações");
            }
        }


    }
}
