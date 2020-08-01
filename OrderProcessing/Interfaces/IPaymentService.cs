using System.Threading.Tasks;

namespace OrderProcessing.Interfaces
{
    /// <summary>
    /// Defines methods for post order payment
    /// </summary>
    public interface IPaymentService
    {
        /// <summary>
        /// Gets or sets payment made for service type
        /// </summary>
        public string PaymentFor { get; set; }

        /// <summary>
        /// Services to be executed post payment made
        /// </summary>
        /// <returns>Name of executed service</returns>
        Task<string> ProcessPostOrderPaymentAsync();
    }
}
