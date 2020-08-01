using OrderProcessing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderProcessing.Exceptions;

namespace OrderProcessing.Services
{
    public class OrderProcessorService : IOrderProcessor
    {
        private readonly IEnumerable<IPaymentService> _paymentServices;

        public OrderProcessorService(IEnumerable<IPaymentService> paymentServices)
        {
            _paymentServices = paymentServices;
        }

        public async Task<string> ProcessOrderPaymentAsync(string paymentFor)
        {
            try
            {
                var postPaymentService = GetPostPaymentServiceInstance(paymentFor);
                Console.WriteLine("Started processing order payment request for {0}.", postPaymentService.GetType().Name);
                var paymentServiceCalled = await postPaymentService.ProcessPostOrderPaymentAsync();
                Console.WriteLine("Processed order payment request for {0}", paymentServiceCalled);
                return paymentServiceCalled;
            }
            catch (Exception ex) when (ex is PaymentServiceNotConfiguredException)
            {
                Console.WriteLine("Error at:  {0}, \nError message: {1}", nameof(OrderProcessorService), ex.Message);
                //Log exception or perform required operation
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //Log exception or perform required operation
            }

            return null;
        }

        private IPaymentService GetPostPaymentServiceInstance(string paidForService)
        {
            var isMapperInstanceAvailable = _paymentServices.Any(p => p.PaymentFor.Equals(paidForService, StringComparison.OrdinalIgnoreCase));
            if (!isMapperInstanceAvailable)
                throw new PaymentServiceNotConfiguredException($"Payment service is not configured for '{paidForService.ToUpper()}' service.");

            return _paymentServices.Single(p => p.PaymentFor.Equals(paidForService, StringComparison.OrdinalIgnoreCase));
        }
    }
}
