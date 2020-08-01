using OrderProcessing.Business.Constants;
using OrderProcessing.Interfaces;
using System;
using System.Threading.Tasks;

namespace OrderProcessing.Services
{
    public class BookPaymentService : CalculateCommissionPaymentBase, IPaymentService
    {
        public string PaymentFor { get; set; }

        public BookPaymentService()
        {
            PaymentFor = PaymentServiceFor.Book.ToString();
        }

        public Task<string> ProcessPostOrderPaymentAsync()
        {
            Console.WriteLine("Started creating duplicate packaging slip for royalty department.");

            //Do creating packaging slip for royalty department operation here.
            GenerateCommission();

            Console.WriteLine("Completed creating packaging slip for royalty department.");

            return Task.Run(() => nameof(BookPaymentService));
        }
    }
}
