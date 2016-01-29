using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileProcessingModule.PaymentService
{
    public class BetaPaymentService :PaymentServiceBase
    {

        /// <summary>
        /// Get payments entries for  Beta
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public override List<string> GetPaymentEntries(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException("Method received a null argument!");
            if (!File.Exists(filePath))
                throw new FileNotFoundException(string.Format("{0} is not a valid file or directory.", filePath));
            if (new FileInfo(filePath).Length == 0)
                throw new NullReferenceException(string.Format("{0} is a empty file.", filePath));

            var entries = File.ReadAllLines(filePath).Skip(1);
            if (entries.Count() > 0)
            {
                var entriesList = entries.ToList();
                entriesList.RemoveAt(entriesList.Count() - 1);
                return entriesList;
            }
            else
                throw new NullReferenceException(string.Format("{0} is a empty file.", filePath));
        }

        /// <summary>
        /// Get  closing entry for  Beta
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public string GetClosingEntry(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException("Method received a null argument!");
            if (!File.Exists(filePath))
                throw new FileNotFoundException(string.Format("{0} is not a valid file or directory.", filePath));
            if (new FileInfo(filePath).Length == 0)
                throw new NullReferenceException(string.Format("{0} is a empty file.", filePath));

            string entry = File.ReadLines(filePath).Last();

            return entry;
        }

        /// <summary>
        /// Get the sum of payment entries for  Beta
        /// </summary>
        /// <param name="paymentEntries"></param>
        /// <returns></returns>
        public override float GetPaymentEntrySum(List<string> paymentEntries)
        {
           
            var listInt = paymentEntries.Select((x) => float.Parse(x.Substring(2, 20).Trim()));
           
            return listInt.Sum();

        }
        /// <summary>
        /// Files processing for  Beta
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="absolutePath"></param>
        /// <returns></returns>
        public override string FileProcessing(string fileName, string absolutePath)
        {

            var files = GetFiles(fileName, absolutePath);
            var openingEntry = GetOpeningEntry(files[0]);
            var paymentEntries = GetPaymentEntries(files[0]);

            var closingEntry = GetClosingEntry(files[0]);

            var type = GetSubString(openingEntry, 0, 2);
            var clearingNumber = GetSubString(openingEntry, 10, 4);
            var accountNumber = GetSubString(openingEntry, 14, 10);
            var closingSum = GetSubString(closingEntry, 2, 20);        
            
            
            var paymentSum = GetPaymentEntrySum(paymentEntries);


            if (ValidateIntegerValue(clearingNumber) && ValidateIntegerValue(accountNumber) && ValidateWidthFixedValue("00", type))
            {

                return "Calls to IPaymentReceiver";
            }

            return "File data is not valid";
        }       
    }
}


