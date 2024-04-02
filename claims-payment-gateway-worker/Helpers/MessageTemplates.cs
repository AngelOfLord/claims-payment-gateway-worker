using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace claims_payment_gateway_worker.Helpers
{
    internal static class MessageTemplates
    {
        public const string AppStarted = @"App Started Processing {message}";
        public const string AppCompleted = @"App Completed Processed {message}";
    }
}
