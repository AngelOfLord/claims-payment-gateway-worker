using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace claims_payment_gateway_worker.Domain.Core
{
    internal class Payable
    {
        public bool IsDigtalPayment { get; set; }
        public int ClaimNumber { get; set; }
        public int ParticipantId { get; set; }
    }
}
