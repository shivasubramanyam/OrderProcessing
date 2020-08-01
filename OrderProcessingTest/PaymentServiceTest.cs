using NUnit.Framework;
using OrderProcessing.Interfaces;
using OrderProcessing.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using OrderProcessing.Exceptions;

namespace OrderProcessingTest
{
    public class Tests
    {
        private OrderProcessorService _orderProcessorService;
        private IEnumerable<IPaymentService> _paymentServices;

        [SetUp]
        public void Setup()
        {
            var physicalProductPaymentService = new PhysicalProductPaymentService();
            var bookPaymentService = new BookPaymentService();
            var membershipPaymentService = new MembershipPaymentService();
            var upgradeMembershipPaymentService = new UpgradeMembershipPaymentService();
            _paymentServices = new List<IPaymentService>{physicalProductPaymentService, bookPaymentService, membershipPaymentService, upgradeMembershipPaymentService};
            _orderProcessorService = new OrderProcessorService(_paymentServices);
        }

        [Test]
        public async Task When_Payment_Made_Is_For_PhysicalProduct_Generate_PackagingSlip_And_Commission()
        {
            var servicePaidFor = "PhysicalProduct";

            var response = await _orderProcessorService.ProcessOrderPaymentAsync(servicePaidFor);

            Assert.NotNull(response);
            Assert.AreEqual("PhysicalProductPaymentService", response);
        }

        [Test]
        public async Task When_Payment_Made_Is_For_Book_Generate_DuplicatePackagingSlipForRoyaltyDept_And_Commission()
        {
            var servicePaidFor = "Book";

            var response = await _orderProcessorService.ProcessOrderPaymentAsync(servicePaidFor);

            Assert.NotNull(response);
            Assert.AreEqual("BookPaymentService", response);
        }

        [Test]
        public async Task When_Payment_Made_Is_For_Membership_ActivateMembership_And_EmailUserAboutActivation()
        {
            var servicePaidFor = "Membership";

            var response = await _orderProcessorService.ProcessOrderPaymentAsync(servicePaidFor);

            Assert.NotNull(response);
            Assert.AreEqual("MembershipPaymentService", response);
        }

        [Test]
        public async Task When_Payment_Made_Is_For_UpgradeMembership_UpgradeMembershipService_And_EmailUserAboutUpGradation()
        {
            var servicePaidFor = "UpgradeMembership";

            var response = await _orderProcessorService.ProcessOrderPaymentAsync(servicePaidFor);

            Assert.NotNull(response);
            Assert.AreEqual("UpgradeMembershipPaymentService", response);
        }


        [Test]
        public void When_Non_Configured_PaymentService_Is_Requested_Throws_PaymentServiceNotConfiguredException_And_IsHandled()
        {
            var servicePaidFor = "CricketCoaching";

            var ex = Assert.ThrowsAsync<PaymentServiceNotConfiguredException>(async () => await _orderProcessorService.ProcessOrderPaymentAsync(servicePaidFor));

            Assert.NotNull(ex);
            Assert.AreEqual($"Payment service is not configured for '{servicePaidFor.ToUpper()}' service.", ex.Message);
        }

        [Test]
        public void When_PaymentService_Is_Null_Throws_NullReferenceException_And_IsHandled()
        {
            Assert.DoesNotThrowAsync(async () => await _orderProcessorService.ProcessOrderPaymentAsync(null));
        }
    }
}