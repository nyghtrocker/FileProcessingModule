using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileProcessingModule.PaymentService;

namespace FileProcessingModuleTest
{
    [TestClass]
    public class PaymentServiceTest
    {
        PaymentService paymentService;
        [TestInitialize]
        public void SetUp()
        {
            paymentService = new PaymentService();
                    
        }

        [TestMethod]
        public void TestMain()
        {
           
            Assert.AreEqual("Calls to IPaymentReceiver", paymentService.Main("example_betapayment.txt"));
            Assert.AreEqual("File data is not valid", paymentService.Main("example_alphapayment.txt"));
        }
    }
}
