using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using claims_payment_gateway_worker.Domain.Core;
using claims_payment_gateway_worker.Repository.DataProviders.Abstractions;

namespace claims_payment_gateway_worker.Repository.DataProviders.Implementations
{
    internal class FinancialDataProvider : IFinancialDataProvider
    {
        public Task CreateAchPayments(IEnumerable<Ach> achPayments, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task CreateCheckPayments(IEnumerable<Check> checks, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BankAccount>> GetActiveBankAccounts(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PreferenceDto>> GetPaymentPreferneces(IEnumerable<(int Id, int ClaimNumber)> pairs, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Payable>> GetReleasedPayments(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBankAccount(int Id, BankAccount bankAccount, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
