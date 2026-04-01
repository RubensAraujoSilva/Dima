using Dima.Core.Handlers;
using Dima.Core.Requests.Reports;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Dima.Web.Components.Reports;

public partial class ExpensesByCategoryChartComponent : ComponentBase
{
    #region Properties

    public List<double> Data { get; set; } = [];
    public List<string> Labels { get; set; } = [];

    #endregion

    #region Services

    [Inject] public IReportHandler Handler { get; set; } = null!;
    [Inject] public ISnackbar Snackbar { get; set; } = null!;

    #endregion

    #region Overrides

    protected override async Task OnInitializedAsync()
    {
        await GetExpensesByCategoryChartAsync();
    }

    private async Task GetExpensesByCategoryChartAsync()
    {
        var request = new GetExpensesByCategoryRequest();
        var result = await Handler.GetExpensesByCategoryReportAsync(request);

        if (!result.IsSuccess || result.Data is null)
        {
            Snackbar.Add("Falha ao obter dados do relatório", Severity.Error);
            return;
        }

        if (result.Data != null)
        {
            foreach (var item in result.Data)
            {
                Labels.Add($"{item.Category}");
                Data.Add(-(double)item.Expenses); //Converte a despesa negativa em positova 
            }
        }
    }

    #endregion
}