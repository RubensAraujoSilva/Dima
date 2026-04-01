namespace Dima.Core.Models.Reports;

//Entradas por Categorias 
public record IncomesByCategory(string UserId, string Category, int Year, decimal Incomes);