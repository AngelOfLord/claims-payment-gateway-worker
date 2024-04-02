using claims_payment_gateway_worker.Domain.Abstractions;

namespace claims_payment_gateway_worker.Domain.Core
{
    internal class Check : Payment
    {
        public int CheckNumber { get; set; }
    }
}