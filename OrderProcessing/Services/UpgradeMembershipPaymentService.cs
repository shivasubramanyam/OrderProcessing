using OrderProcessing.Business.Constants;
using OrderProcessing.Interfaces;
using System;
using System.Threading.Tasks;

namespace OrderProcessing.Services
{
    public class UpgradeMembershipPaymentService : NotificationBase, IPaymentService
    {
        public string PaymentFor { get; set; }

        public UpgradeMembershipPaymentService()
        {
            PaymentFor = PaymentServiceFor.UpgradeMembership.ToString();
        }

        public Task<string> ProcessPostOrderPaymentAsync()
        {
            Console.WriteLine("Started processing upgrade membership.");

            //Do packaging slip for shipping operation here.
            NotifyUser();

            Console.WriteLine("Completed processing upgrade membership.");

            return Task.Run(() => nameof(UpgradeMembershipPaymentService));
        }

        protected override void NotifyUser()
        {
            Console.WriteLine("Preparing message to notify user about his/her membership upgrade activation.");
            Console.WriteLine("The user has been been notified!");
        }
    }
}
