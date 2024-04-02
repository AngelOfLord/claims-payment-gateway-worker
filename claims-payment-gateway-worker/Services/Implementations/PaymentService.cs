using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using claims_payment_gateway_worker.Domain.Core;
using claims_payment_gateway_worker.Helpers;
using claims_payment_gateway_worker.Repository.DataProviders.Abstractions;
using claims_payment_gateway_worker.Services.Abstractions;

namespace claims_payment_gateway_worker.Services.Implementations
{
    internal class PaymentService : IPaymentService
    {
        private readonly IFinancialDataProvider _financialDataProvider;
        private readonly ILogger<PaymentService> _logger;
        private readonly IMapper _mapper;
        private readonly IEqualityComparer<(int, int)> _comparer;

        public PaymentService(IFinancialDataProvider financialDataProvider, ILogger<PaymentService> logger, IMapper mapper)
        {
            _financialDataProvider = financialDataProvider;
            _logger = logger;
            _mapper = mapper;
            _comparer = EqualityComparer<(int, int)>.Create((x, y) => x.Item1 == y.Item1 && x.Item2 == y.Item2);
        }

        public async Task ProcessReleasedPayments(CancellationToken cancellationToken)
        {
            _logger.LogTrace(MessageTemplates.AppStarted, "Released Payments");
            var bankAccounts = await _financialDataProvider.GetActiveBankAccounts(cancellationToken);
            foreach ( var bankAccount in bankAccounts )
            {
                var payments = await _financialDataProvider.GetReleasedPayments(bankAccount.Id, cancellationToken);
                var achPayments = payments.Where(x => x.IsDigtalPayment);
                var checkPayments = payments.Where(x => !x.IsDigtalPayment);


            }
            _logger.LogTrace(MessageTemplates.AppCompleted, "Released Payments");
        }

        private async Task ProcessCheckPayments(IEnumerable<Payable> payments, BankAccount bankAccount, CancellationToken cancellationToken)
        {
            var checkSequnece = bankAccount.CheckSequence; 
            var checks = _mapper.Map<IEnumerable<Check>>(payments);

            foreach( var check in checks)
            {
                check.CheckNumber = ++checkSequnece;
            }

            bankAccount.CheckSequence = checkSequnece;
            await _financialDataProvider.CreateCheckPayments(checks, cancellationToken);
            await _financialDataProvider.UpdateBankAccount(bankAccount.Id, bankAccount, cancellationToken);
        }

        private async Task ProcessAchPayments(IEnumerable<Payable> payables, CancellationToken cancellationToken)
        {
            var claimParticipantPairs = payables
                .Select(x => (x.ParticipantId, x.ClaimNumber))
                .Distinct(_comparer);
            var preferences = await _financialDataProvider.GetPaymentPreferneces(claimParticipantPairs, cancellationToken);

            var preferenceStore = preferences.ToLookup(x => x.Id);
            var paymentGroups = payables.ToLookup(x => x.ParticipantId);
            List<IEnumerable<Payable>> failedPayments = [];

            foreach (var paymentGroup in paymentGroups)
            {
                var payments = paymentGroups[paymentGroup.Key];
                if (!preferenceStore.Contains(paymentGroup.Key))
                {
                    failedPayments.Add(payments);
                    continue;
                }

                var participantPreferences = preferenceStore[paymentGroup.Key]
                    .ToDictionary(x => x.ClaimNumber);

                var achPayments = payments.Select(x => CreateAchPayements(x, participantPreferences));

            }
        }

        private IEnumerable<Ach> CreateAchPayements(Payable payments, IDictionary<int, PreferenceDto> preference)
        {
            List<Ach> achPayments = [];

            return achPayments;
        }
    }
}
