using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSuiBeauty.Models
{
    public class PaymentMethod
    {
        public static class DefaultPaymentMethods
        {
            public const string ATM = "ATM";
            public const string Cash = "Tiền mặt";
            public const string StorePayment = "Thanh toán tại cửa hàng";
        }
    }
}