using claims_payment_gateway_worker.Domain.Core;

namespace claims_payment_gateway_worker.Repository.DataProviders.Abstractions
{
    internal interface IFinancialDataProvider
    {
        Task<IEnumerable<BankAccount>> GetActiveBankAccounts(CancellationToken cancellationToken);
        Task<IEnumerable<Payable>> GetReleasedPayments(int id, CancellationToken cancellationToken);
        Task<IEnumerable<PreferenceDto>> GetPaymentPreferneces(IEnumerable<(int Id, int ClaimNumber)> pairs, CancellationToken cancellationToken);
        Task CreateCheckPayments(IEnumerable<Check> checks, CancellationToken cancellationToken);
        Task CreateAchPayments(IEnumerable<Ach> achPayments, CancellationToken cancellationToken);
        Task UpdateBankAccount(int Id, BankAccount bankAccount, CancellationToken cancellationToken);
    }
}