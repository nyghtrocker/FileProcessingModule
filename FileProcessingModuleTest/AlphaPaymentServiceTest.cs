using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileProcessingModule.PaymentService;
using System.IO;
using System.Collections.Generic;
namespace FileProcessingModuleTest
{
    [TestClass]
    public class AlphaPaymentServiceTest
    {
        private AlphaPaymentService alphaPaymentService;
        private string baseDirectory;
        const string relativePath = @"..\\FileProcessingModule\FileProcessingModule\PaymentServiceFiles";
        string absolutePath;
        const string filesName = @"*_alphapayment.txt";
        [TestInitialize]
        public void SetUp()
        {
            alphaPaymentService = new AlphaPaymentService();
            baseDirectory = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName);
            absolutePath = alphaPaymentService.GetFullPath(baseDirectory, relativePath);
        }
        [TestMethod]
        public void TestGetFullPath()
        {
            Assert.AreEqual("C:\\Assignments\\FileProcessingModule\\FileProcessingModule\\PaymentServiceFiles", alphaPaymentService.GetFullPath(baseDirectory, relativePath));
        }
        [TestMethod]
        public void TestGetFilesAlpha()
        {
           var files = alphaPaymentService.GetFiles(filesName, absolutePath);
           Assert.IsNotNull(files);
           Assert.AreEqual(1, files.Count);
           
        }
        [TestMethod]
        public void TestGetOpeningEntry()
        {
            var files = alphaPaymentService.GetFiles(filesName, absolutePath);
            var openingEntry = alphaPaymentService.GetOpeningEntry(files[0]);

            Assert.IsNotNull(files);
            Assert.IsNotNull(openingEntry);

        }
        [TestMethod]
        public void TestGetPaymentEntries()
        {
            var files = alphaPaymentService.GetFiles(filesName, absolutePath);
            var paymentEntries = alphaPaymentService.GetPaymentEntries(files[0]);
            Assert.IsNotNull(files);
            Assert.AreEqual(4, paymentEntries.Count);
        }

         [TestMethod]
        public void TestValidateAccountNumber()
        {
            var files = alphaPaymentService.GetFiles(filesName, absolutePath);
            var openingEntry = alphaPaymentService.GetOpeningEntry(files[0]);

            var account = alphaPaymentService.GetSubString(openingEntry, 1, 15);

            Assert.AreEqual("4367 4791351255", account);
        }
    }
}
