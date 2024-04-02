using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using claims_payment_gateway_worker.Domain.Core;
using claims_payment_gateway_worker.Services.Abstractions;

namespace claims_payment_gateway_worker.Services.Implementations
{
    internal class PrintService : IPrintService
    {
        public Task<IDictionary<int, Guid>> Print(IEnumerable<Check> checks)
        {
            throw new NotImplementedException();
        }
    }
}
