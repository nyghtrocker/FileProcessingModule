using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileProcessingModule.PaymentService;
using System.IO;
using System.Collections.Generic;
namespace FileProcessingModuleTest
{
    [TestClass]
    public class BetaPaymentServiceTest
    {
        private BetaPaymentService betaPaymentService;
        private string baseDirectory;
        const string relativePath = @"..\\FileProcessingModule\FileProcessingModule\PaymentServiceFiles";
        string absolutePath;
        const string filesName = @"*_betapayment.txt";
        [TestInitialize]
        public void SetUp()
        {
            betaPaymentService = new BetaPaymentService();
            baseDirectory = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName);
            absolutePath = betaPaymentService.GetFullPath(baseDirectory, relativePath);
        }

       
        [TestMethod]
        public void TestGetFullPath()
        {
            Assert.AreEqual("C:\\Assignments\\FileProcessingModule\\FileProcessingModule\\PaymentServiceFiles", betaPaymentService.GetFullPath(baseDirectory, relativePath));
        }


        [TestMethod]
        public void TestGetFilesBeta()
        {
            var files = betaPaymentService.GetFiles(filesName, absolutePath);
            Assert.IsNotNull(files);
            Assert.AreEqual(1, files.Count);

        }

        [TestMethod]
        public void TestGetOpeningEntry()
        {
            var files = betaPaymentService.GetFiles(filesName, absolutePath);
            var openingEntry = betaPaymentService.GetOpeningEntry(files[0]);
            Assert.IsNotNull(files);
            Assert.IsNotNull(openingEntry);
        }

        [TestMethod]
        public void TestGetClosingEntry()
        {
            var files = betaPaymentService.GetFiles(filesName, absolutePath);
            var closingEntry = betaPaymentService.GetClosingEntry(files[0]);
            Assert.IsNotNull(files);
            Assert.IsNotNull(closingEntry);
        }

        [TestMethod]
        public void TestGetPaymentEntries()
        {
            var files = betaPaymentService.GetFiles(filesName, absolutePath);
            var paymentEntries = betaPaymentService.GetPaymentEntries(files[0]);
            Assert.IsNotNull(files);
            Assert.AreEqual(3, paymentEntries.Count);
        }


        [TestMethod]
        public void TestClearingNumber()
        {
            var files = betaPaymentService.GetFiles(filesName, absolutePath);
            var openingEntry = betaPaymentService.GetOpeningEntry(files[0]);
            var clearingNumber = betaPaymentService.GetSubString(openingEntry, 10, 4);
            var accountNumber = betaPaymentService.GetSubString(openingEntry, 14, 10);
           
            Assert.IsNotNull(files);
            Assert.IsNotNull(openingEntry);
            Assert.IsNotNull(clearingNumber);
            Assert.AreEqual("5467", clearingNumber);
            Assert.AreEqual(true , betaPaymentService.ValidateIntegerValue(clearingNumber));
            
        }
        
        [TestMethod]
        public void TestAccountNumber()
        {
            var files = betaPaymentService.GetFiles(filesName, absolutePath);
            var openingEntry = betaPaymentService.GetOpeningEntry(files[0]);
          
            var accountNumber = betaPaymentService.GetSubString(openingEntry, 14, 10);

            Assert.IsNotNull(files);
            Assert.IsNotNull(openingEntry);
            Assert.IsNotNull(accountNumber);
            Assert.AreEqual("2334653563", accountNumber);
            Assert.AreEqual(true, betaPaymentService.ValidateIntegerValue(accountNumber));
           
        }
    }
}

