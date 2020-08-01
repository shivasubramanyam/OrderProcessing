using OrderProcessing.Business.Constants;
using OrderProcessing.Interfaces;
using System;
using System.Threading.Tasks;

namespace OrderProcessing.Services
{
    public class PhysicalProductPaymentService : CommissionPaymentBase, IPaymentService
    {
        public string PaymentFor { get; set; }

        public PhysicalProductPaymentService()
        {
            PaymentFor = PaymentServiceFor.PhysicalProduct.ToString();
        }

        public Task<string> ProcessPostOrderPaymentAsync()
        {
            Console.WriteLine("Started generating packaging slip for shipping.");

            //Do packaging slip for shipping operation here.
            GenerateCommission();
            
            Console.WriteLine("Completed generating packaging slip for shipping.");

            return Task.Run(() => nameof(PhysicalProductPaymentService));
        }
    }
}
