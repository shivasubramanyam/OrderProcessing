using System.Threading.Tasks;

namespace OrderProcessing.Interfaces
{
    /// <summary>
    /// Defines methods for order processing
    /// </summary>
    public interface IOrderProcessor
    {
        /// <summary>
        /// Processes order payment
        /// </summary>
        /// <param name="paymentFor">Specifies payment made for service provided</param>
        /// <returns>No return</returns>
        Task<string> ProcessOrderPaymentAsync(string paymentFor);
    }
}
