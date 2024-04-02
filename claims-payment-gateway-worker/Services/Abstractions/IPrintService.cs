using claims_payment_gateway_worker.Domain.Core;

namespace claims_payment_gateway_worker.Services.Abstractions
{
    internal interface IPrintService
    {
        Task<IDictionary<int, Guid>> Print(IEnumerable<Check> checks);
    }
}