using KernelFramework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SEMS.Core.Constant
{
    public class NodeResult : BaseResult
    {
        public NodeResult(string message, string code, HttpStatusCode httpStatus) : base(message, code, httpStatus)
        {
            this.ActionMessage = message;
            this.ActionCode = code;
            this.HttpStatus = httpStatus;
        }

        public static NodeResult PaymentOk => new NodeResult("پرداخت موفق بود ولی ممکن است اعمال آن به حساب سازمان مربوطه زمانبر باشد.", "00000", HttpStatusCode.OK);

    }
}
