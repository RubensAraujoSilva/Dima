namespace Dima.Core.Models.Reports;

//Entradas e Saídas
public record IncomesAndExpenses(string UserId, int Month, int Year, decimal Incomes, decimal Expenses );