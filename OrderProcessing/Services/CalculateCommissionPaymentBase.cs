using System;

namespace OrderProcessing.Services
{
    public abstract class CalculateCommissionPaymentBase
    {
        protected void GenerateCommission()
        {
            Console.WriteLine("Started generating commission.");
            Console.WriteLine("Commission amount to be paid for the agent is: {0}", CalculateCommission());
            Console.WriteLine("Completed generating commission.");
        }

        private double CalculateCommission()
        {
            Console.WriteLine("Started calculating commission.");
            var commission = 7733.77;
            Console.WriteLine("Completed calculating commission.");

            return commission;
        }
    }
}
