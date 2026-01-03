using System;
using System.Collections.Generic;
using System.Text;

namespace Dima.Core.Common.Extensions
{
    public static class DateTimeExtension
    {
        public static DateTime GetFirstDay(this DateTime date, int? year = null, int? month = null)
         => new(year ?? date.Year, month ?? date.Year, 1); // Retorna o primeiro dia do mês

        public static DateTime GetLastDay(this DateTime date, int? year = null, int? month = null)
         => new DateTime(year ?? date.Year, month ?? date.Year, 1).AddMonths(1).AddDays(-1); // Retorna o último dia do mês
        //Pega o primeiro dia do mês seguinte adiciona mais um mês e subtrai um dia
    }
}
