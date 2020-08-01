using OrderProcessing.Business.Constants;
using OrderProcessing.Interfaces;
using System;
using System.Threading.Tasks;

namespace OrderProcessing.Services
{
    public class MembershipPaymentService : NotificationBase, IPaymentService
    {
        public string PaymentFor { get; set; }

        public MembershipPaymentService()
        {
            PaymentFor = PaymentServiceFor.Membership.ToString();
        }

        public Task<string> ProcessPostOrderPaymentAsync()
        {
            Console.WriteLine("Started processing membership activation.");

            //Do packaging slip for shipping operation here.
            NotifyUser();

            Console.WriteLine("Completed processing membership activation.");

            return Task.Run(() => nameof(MembershipPaymentService));
        }

        protected override void NotifyUser()
        {
            Console.WriteLine("Preparing message to notify user about his/her membership activation.");
            Console.WriteLine("The user has been been notified!");
        }
    }
}
