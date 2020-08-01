using Microsoft.Extensions.DependencyInjection;
using OrderProcessing.Interfaces;
using OrderProcessing.Services;
using System;

namespace OrderProcessing.Bootstrapper
{
    /// <summary>
    /// Bootstraps the application by registering services required for the application
    /// </summary>
    internal static class ApplicationBuilder
    {
        private static ServiceProvider _serviceProvider;

        /// <summary>
        /// Register services used by the application
        /// </summary>
        public static void RegisterServices()
        {
            var service = new ServiceCollection();
            service.AddSingleton<IOrderProcessor, OrderProcessorService>();
            service.AddSingleton<IPaymentService, PhysicalProductPaymentService>();
            service.AddSingleton<IPaymentService, BookPaymentService>();
            service.AddSingleton<IPaymentService, MembershipPaymentService>();
            service.AddSingleton<IPaymentService, UpgradeMembershipPaymentService>();
            _serviceProvider = service.BuildServiceProvider(true);
        }

        /// <summary>
        /// Disposes service provider instance
        /// </summary>
        public static void DisposeServiceInstance()
        {
            if (_serviceProvider != null && _serviceProvider is IDisposable)
                _serviceProvider.Dispose();
        }

        public static ServiceProvider GetServiceProviderInstance() => _serviceProvider;
    }
}
