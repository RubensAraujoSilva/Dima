using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Requests.Transactions;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Dima.Web.Pages.Transactions;

public partial class EditTransactionPage : ComponentBase
{
    #region Properties

    [Parameter] public long Id { get; set; }
    protected bool IsBusy { get; set; } = false;
    protected UpdateTransactionRequest InputModel { get; set; } = new();
    protected List<Category> Categorias { get; set; } = [];

    #endregion

    #region Services

    [Inject] public ISnackbar Snackbar { get; set; } = null!;
    [Inject] public ITransactionHandler TransactionHandler { get; set; } = null!;
    [Inject] public ICategoryHandler CategoryHandler { get; set; } = null!;
    [Inject] public NavigationManager NavigationManager { get; set; } = null!;

    #endregion

    #region Overrides

    protected override async Task OnInitializedAsync()
    {
        await GetCategoriesAsync();
        await GetTransactionByIdAsync(Id);
    }

    #endregion

    #region Methods

    private async Task GetCategoriesAsync()
    {
        try
        {
            IsBusy = true;
            var request = new GetAllCategoriesRequest();
            var resuult = await CategoryHandler.GetAllAsync(request);
            
            if (resuult.IsSuccess)
            {
                Categorias = resuult.Data ?? [];
            }
            else
                Snackbar.Add("Erro ao carregas as categorias", Severity.Error);
        }
        catch (Exception e)
        {
            Snackbar.Add(e.Message, Severity.Error);
        }
        finally
        {
            IsBusy = false;
        }
    }
    private async Task GetTransactionByIdAsync(long id)
    {
        try
        {
            IsBusy = true;
            var request = new GetByIdTransactionRequest {Id = id};
            var result = await TransactionHandler.GetByIdAsync(request);
            
            if (result is { IsSuccess: true, Data: not null })
            {
                InputModel = new UpdateTransactionRequest
                {
                    Id = result.Data.Id,
                    Title = result.Data.Title,
                    Amount = result.Data.Amount,
                    CategoryId = result.Data.CategoryId,
                    Type = result.Data.Type, 
                    PaidOrReceivedAt = result.Data.PaidOrReceivedAt
                };
            }
            else
                Snackbar.Add("Erro ao carregas o lançamento", Severity.Error);
        }
        catch (Exception e)
        {
            Snackbar.Add(e.Message, Severity.Error);
        }
        finally
        {
            IsBusy = false;
        }
    }

    public async Task OnValidSubmitAsync()
    {
        IsBusy = true;
        try
        {
            if (InputModel.CategoryId == 0)
            {
                Snackbar.Add("Você precisa informar uma categoria", Severity.Info);
                return;
            }

            var resuult = await TransactionHandler.UpdateAsync(InputModel);

            if (resuult.IsSuccess)
            {
                Snackbar.Add(resuult.Message, Severity.Success);
                NavigationManager.NavigateTo("/lancamentos/historico");
            }
            else
                Snackbar.Add(resuult.Message, Severity.Error);
        }
        catch (Exception e)
        {
            Snackbar.Add(e.Message, Severity.Error);
        }
        finally
        {
            IsBusy = false;
        }
    }

    #endregion
}