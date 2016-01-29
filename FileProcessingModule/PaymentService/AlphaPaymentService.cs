using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;
namespace FileProcessingModule.PaymentService
{
    public class AlphaPaymentService : PaymentServiceBase
    {  
        /// <summary>
        /// Alpha files processing method
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="absolutePath"></param>
        /// <returns></returns>
         public override string FileProcessing(string fileName, string absolutePath)
        {
            var files = GetFiles(fileName, absolutePath);
            var firstEntry =    GetOpeningEntry(files[0]);
            var paymentEntries = GetPaymentEntries(files[0]);

            var type = GetSubString(firstEntry, 0, 1);
            var account = GetSubString(firstEntry, 1, 15);
            var amount = GetSubString(firstEntry, 16, 14);
            var paymentSum = GetPaymentEntrySum(paymentEntries);

            if (ValidateAccountNumber(account) && ValidateWidthFixedValue("O", type) && ValidateAmount(amount, paymentSum.ToString()))
            {

                return "Calls to IPaymentReceiver";
            }
            return "File data is not valid";
        }
        /// <summary>
         /// Validate the Alpha files account  number 
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
       public bool ValidateAccountNumber(string accountNumber)
        {
            return Regex.IsMatch(accountNumber, @"^[0-9]*\s[0-9]\d+");
        }

        /// <summary>
       /// Get the sum for Alpha files
        /// </summary>
        /// <param name="paymentEntries"></param>
        /// <returns></returns>
        public override float GetPaymentEntrySum(List<string> paymentEntries)
       {
           var listInt = paymentEntries.Select((x) => float.Parse(x.Substring(1, 14).Trim()));

           return listInt.Sum();
       }
    }
}

