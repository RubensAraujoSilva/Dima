using Dima.Core.Handlers;
using Dima.Core.Requests.Account;
using Dima.Core.Requests.Categories;
using Dima.Web.Security;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Dima.Web.Pages.Categories;

public partial class CreateCategoryPage : ComponentBase
{
    #region Properties

    protected bool IsBusy { get; set; } = false; //Define se a página está em uso 
    public CreateCategoryRequest InputModel { get; set; } = new();

    #endregion

    #region Services

    [Inject] public ISnackbar Snackbar { get; set; } = null!;

    [Inject] public ICategoryHandler Handler { get; set; } = null!;

    [Inject] public NavigationManager NavigationManager { get; set; } = null!;

    #endregion

    #region Methods

    public async Task OnValidSubmitAsync()
    {
        IsBusy = true;
        try
        {
            var resuult = await Handler.CreateAsync(InputModel);

            if (resuult.IsSuccess)
            {
                Snackbar.Add(resuult.Message, Severity.Success);
                NavigationManager.NavigateTo("/categorias");
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