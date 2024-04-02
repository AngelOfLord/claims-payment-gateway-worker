using claims_payment_gateway_worker.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace claims_payment_gateway_worker.Domain.Core
{
    internal class Ach : Payment, ICloneable
    {
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
