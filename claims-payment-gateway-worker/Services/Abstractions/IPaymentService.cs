namespace claims_payment_gateway_worker.Services.Abstractions
{
    internal interface IPaymentService
    {
        Task ProcessReleasedPayments(CancellationToken cancellation);
    }
}