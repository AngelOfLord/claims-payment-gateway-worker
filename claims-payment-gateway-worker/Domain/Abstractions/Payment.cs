using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace claims_payment_gateway_worker.Domain.Abstractions
{
    internal abstract class Payment
    {
        public int Id { get; set; }
    }
}
