using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Dima.Web.Pages.Categories;

public partial class ListCategoriesPage : ComponentBase
{
    #region Properties

    protected bool IsBusy { get; set; } = false; //Define se a página está em uso 
    public List<Category>? Categorias { get; set; } = [];

    public string SearchTerm { get; set; } = string.Empty;

    #endregion
    
    #region Services

    [Inject] public ISnackbar Snackbar { get; set; } = null!;
    [Inject] public IDialogService DialogService { get; set; } = null!;
    [Inject] public ICategoryHandler Handler { get; set; } = null!;
    [Inject] public NavigationManager NavigationManager { get; set; } = null!;

    #endregion

    #region Overrides

    protected override async Task OnInitializedAsync()
    {
        IsBusy = true;
        try
        {
            var request = new GetAllCategoriesRequest();
            var resuult = await Handler.GetAllAsync(request);

            if (resuult.IsSuccess)
                Categorias = resuult.Data ?? [];
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

    #region Methods

    public Func<Category, bool> Filter => category =>
    {
        if (string.IsNullOrEmpty(SearchTerm))
            return true;

        if (category.Id.ToString().Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
            return true;

        if (category.Title.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
            return true;

        if (category.Description.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
            return true;

        return false;
    };

    //Chama o modal para confirmar exclusão 
    public async void OnDeleteButtonClickedAsync(long id, string category)
    {
        var result = await DialogService.ShowMessageBox("Atenção!",
            $"Ao prosseguir a categoria {category} será excluída.Está ação é irreversível! Deseja continuar?",
            "Excluir",
            "Cancelar");

        if (result is true)
            await OnDeleteAsyn(id, category);

        StateHasChanged();
    }

    private async Task OnDeleteAsyn(long id, string category)
    {
        try
        {
            var request = new DeleteCategoryRequest { Id = id };
            var result = await Handler.DeleteAsync(request);

            if (result.IsSuccess)
            {
                Categorias?.RemoveAll(c => c.Id == id);
                Snackbar.Add($"Categoria {category} excluída com sucesso", Severity.Success);
            }
            else
                Snackbar.Add($"Erro ao exclui a categoria {category}", Severity.Error);
        }
        catch (Exception e)
        {
            Snackbar.Add(e.Message, Severity.Error);
        }
    }

    #endregion
}