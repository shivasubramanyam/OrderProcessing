using System;

namespace OrderProcessing.Exceptions
{
    public class PaymentServiceNotConfiguredException : Exception
    {
        public PaymentServiceNotConfiguredException(string message) : base(message)
        {

        }

        public PaymentServiceNotConfiguredException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
