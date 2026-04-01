using Dima.Core.Handlers;
using Dima.Core.Requests.Reports;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Dima.Web.Components.Reports;

public partial class IncomesAndExpensesComponent : ComponentBase
{
    #region Properties

    public ChartOptions ChartOptions { get; set; } = new();
    public List<ChartSeries>? ChartSeries { get; set; }
    public List<string> Labels { get; set; } = [];

    #endregion

    #region Services

    [Inject] public IReportHandler Handler { get; set; } = null!;
    [Inject] public ISnackbar Snackbar { get; set; } = null!;

    #endregion

    #region Overrides

    protected override async Task OnInitializedAsync()
    {
        await GetIncomesByCategoryChartAsync();
    }

    #endregion

    #region Methods

    private async Task GetIncomesByCategoryChartAsync()
    {
        var request = new GetIncomesAndExpensesRequest();
        var result = await Handler.GetIncomesAndExpensesReportAsync(request);

        if (!result.IsSuccess || result.Data is null)
        {
            Snackbar.Add("Falha ao obter dados do relatório", Severity.Error);
            return;
        }

        var incomes = new List<double>(); //Entradas
        var expenses = new List<double>(); //Saídas

        foreach (var item in result.Data)
        {
            incomes.Add((double)item.Incomes);
            expenses.Add(-(double)item.Expenses);
            Labels.Add(GetMonthName(item.Month));
        }

        ChartOptions.YAxisTicks = 1000;
        ChartOptions.LineStrokeWidth = 5;
        ChartOptions.ChartPalette = [Colors.Green.Accent4, Colors.Red.Default];
        ChartSeries =
        [
            new ChartSeries { Name = "Receitas", Data = incomes.ToArray() },
            new ChartSeries { Name = "Despesas", Data = expenses.ToArray() }
        ];

        StateHasChanged();
    }

    private static string GetMonthName(int month)
        => new DateTime(DateTime.Now.Year, month, 1).ToString("MMMM");

    #endregion
}