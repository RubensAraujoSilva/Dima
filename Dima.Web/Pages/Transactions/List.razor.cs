using Dima.Core.Common.Extensions;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Requests.Transactions;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Dima.Web.Pages.Transactions;

public partial class ListTransactionsPage : ComponentBase
{
    #region Properties

    protected bool IsBusy { get; set; } = false;
    protected List<Transaction> Transactions { get; set; } = [];
    public string SearchTerm { get; set; } = string.Empty;

    public int CurrentYear { get; set; } = DateTime.Now.Year;
    public int CurrentMonth { get; set; } = DateTime.Now.Month;

    public int[] Years { get; set; } =
    {
        DateTime.Now.Year,
        DateTime.Now.AddYears(-1).Year,
        DateTime.Now.AddYears(-2).Year,
        DateTime.Now.AddYears(-3).Year,
        DateTime.Now.AddYears(-4).Year,
        DateTime.Now.AddYears(-5).Year,
    };

    #endregion

    #region Services

    [Inject] public ISnackbar Snackbar { get; set; } = null!;

    [Inject] public IDialogService DialogService { get; set; } = null!;

    [Inject] public ITransactionHandler TransactionHandler { get; set; } = null!;

    [Inject] public NavigationManager NavigationManager { get; set; } = null!;

    #endregion

    #region Overrides

    protected override async Task OnInitializedAsync() => await GetTransactionsAsync();

    #endregion

    #region Methods

    public async Task OnFilterButtonClickedAsync()
    {
        await GetTransactionsAsync();
        StateHasChanged();
    }
    
    private async Task GetTransactionsAsync()
    {
        IsBusy = true;
        try
        {
            var request = new GetByPeriodTransactionRequest
            {
                StartDate = DateTime.Now.GetFirstDay(CurrentYear, CurrentMonth),
                EndtDate = DateTime.Now.GetLastDay(CurrentYear, CurrentMonth),
                PageNumber = 1,
                PageSize = 1000,
            };

            var resuult = await TransactionHandler.GetByPeriodAsync(request);

            if (resuult.IsSuccess)
                Transactions = resuult.Data ?? [];
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

    public Func<Transaction, bool> Filter => transaction =>
    {
        if (string.IsNullOrEmpty(SearchTerm))
            return true;

        if (transaction.Id.ToString().Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
            return true;

        if (transaction.Title.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
            return true;

        return false;
    };

    //Chama o modal para confirmar exclusão 
    protected async void OnDeleteButtonClickedAsync(long id, string nameTransaction)
    {
        var result = await DialogService.ShowMessageBox("Atenção!",
            $"Ao prosseguir o lançamento: {nameTransaction} será excluído. Está ação é irreversível! Deseja continuar?",
            "Excluir",
            "Cancelar");

        if (result is true)
            await OnDeleteAsync(id, nameTransaction);

        StateHasChanged();
    }

    private async Task OnDeleteAsync(long id, string nameTransaction)
    {
        try
        {
            IsBusy = true;
            var result = await TransactionHandler.DeleteAsync(new DeleteTransactionRequest() { Id = id });

            if (result.IsSuccess)
            {
                Transactions?.RemoveAll(c => c.Id == id);
                Snackbar.Add($"O lançamento {nameTransaction} foi excluído com sucesso", Severity.Success);
            }
            else
                Snackbar.Add($"Erro ao exclui o lançamento {nameTransaction}", Severity.Error);
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