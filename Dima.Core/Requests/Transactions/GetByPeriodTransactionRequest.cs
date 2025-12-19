namespace Dima.Core.Requests.Transactions
{
    public class GetByPeriodTransactionRequest : PagedRequest
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndtDate { get; set; }

    }
}
