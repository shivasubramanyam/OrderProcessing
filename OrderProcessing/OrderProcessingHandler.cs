using Microsoft.Extensions.DependencyInjection;
using OrderProcessing.Bootstrapper;
using OrderProcessing.Business.Constants;
using OrderProcessing.Interfaces;
using System;

namespace OrderProcessing
{
    public class OrderProcessingHandler
    {
        static void Main(string[] args)
        {
            ApplicationBuilder.RegisterServices();
            var serviceProvider = ApplicationBuilder.GetServiceProviderInstance();
            var orderProcessorService = serviceProvider.GetService<IOrderProcessor>();
            Console.WriteLine("Below are available services for which payment can be made: ");
            foreach (var paymentService in Enum.GetValues(typeof(PaymentServiceFor)))
            {
                Console.WriteLine(paymentService);
            }
            Console.Write("\nEnter service for which payment is/was made: ");
            var paymentMadeFor = Console.ReadLine()?.TrimEnd();
            orderProcessorService.ProcessOrderPaymentAsync(paymentMadeFor);
            ApplicationBuilder.DisposeServiceInstance();
        }
    }
}
