using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileProcessingModule.Interfaces;
using System.IO;
using System.Text.RegularExpressions;
namespace FileProcessingModule.PaymentService
{
    /// <summary>
    /// Base class for the payment service and file formates
    /// </summary>
    public abstract class PaymentServiceBase:  IPaymentService
    {
        /// <summary>
        /// Get all the Files from file path
        /// </summary>
        /// <param name="filesName"></param>
        /// <param name="targetDirectory"></param>
        /// <returns></returns>
        public virtual List<string> GetFiles(string filesName, string targetDirectory)
        {
            if (string.IsNullOrEmpty(filesName) || string.IsNullOrEmpty(targetDirectory))
                throw new ArgumentNullException("Method received a null argument!");

            if (!Directory.Exists(targetDirectory))
                throw new DirectoryNotFoundException(string.Format("{0} is not a valid file or directory.", targetDirectory));
           
            return Directory.EnumerateFiles(targetDirectory, filesName, SearchOption.TopDirectoryOnly).ToList();
                           
        }
        /// <summary>
        /// Get the Opening entry from file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public virtual string GetOpeningEntry(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException("Method received a null argument!");
            if (!File.Exists(filePath))
                throw new FileNotFoundException(string.Format("{0} is not a valid file or directory.", filePath));
            if(new FileInfo(filePath).Length ==0)
                throw new NullReferenceException(string.Format("{0} is a empty file.", filePath));
            string entry = File.ReadLines(filePath).First();

            return entry;
        }

        /// <summary>
        /// Get all the payment entries from the file 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public virtual List<string> GetPaymentEntries(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException("Method received a null argument!");
            if (!File.Exists(filePath))
                throw new FileNotFoundException(string.Format("{0} is not a valid file or directory.", filePath));
            if (new FileInfo(filePath).Length == 0)
                throw new NullReferenceException(string.Format("{0} is a empty file.", filePath));

            var entries = File.ReadAllLines(filePath).Skip(1);
            if (entries.Count() > 0)
                return entries.ToList();
            else
                throw new NullReferenceException(string.Format("{0} is a empty file.", filePath));
        }

        /// <summary>
        /// Get the path for the folder where files are located
        /// </summary>
        /// <param name="baseDirectory"></param>
        /// <param name="relativePath"></param>
        /// <returns></returns>
        public string GetFullPath( string baseDirectory, string relativePath)
        {
            if (string.IsNullOrEmpty(relativePath) || string.IsNullOrEmpty(baseDirectory))
                throw new ArgumentNullException("Method received a null argument!");

            return Path.GetFullPath(baseDirectory + relativePath);

        }   
        /// <summary>
        /// Validate the string value 
        /// </summary>
        /// <param name="valueToValidate"></param>
        /// <returns></returns>
        public virtual bool ValidateStringValue(string valueToValidate)
        {

            return Regex.IsMatch(valueToValidate, @"^[A-Z0-9]*$");
        }

        /// <summary>
        /// Validate the Int value
        /// </summary>
        /// <param name="valueToValidate"></param>
        /// <returns></returns>
        public virtual bool ValidateIntegerValue(string valueToValidate)
        {

            return Regex.IsMatch(valueToValidate, @"^[0-9]*$");

        }

        /// <summary>
        /// Validate the field with fixed value
        /// </summary>
        /// <param name="fixedValue"></param>
        /// <param name="valueToValidate"></param>
        /// <returns></returns>
        public virtual bool ValidateWidthFixedValue(string fixedValue, string valueToValidate)
        {

            return fixedValue == valueToValidate ? true : false;
        }

        /// <summary>
        /// Get sub string from original string
        /// </summary>
        /// <param name="originalString"></param>
        /// <param name="startValue"></param>
        /// <param name="endValue"></param>
        /// <returns></returns>
        public virtual string GetSubString(string originalString, int startValue, int endValue)
        {
            if (string.IsNullOrEmpty(originalString) || startValue <0 || endValue < 0)
            {
                return string.Empty;
            }

            return originalString.Substring(startValue, endValue);
            
        }

        /// <summary>
        /// Validate the amount 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="valueToValidate"></param>
        /// <returns></returns>
        public virtual bool ValidateAmount(string value, string valueToValidate)
        {
            var test = value == valueToValidate ? true : false;
            return value == valueToValidate ? true : false;
        }

        /// <summary>
        /// process the file, as file processing is different for each format so abstract method
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="absolutePath"></param>
        /// <returns></returns>
        public abstract string FileProcessing(string filePath, string absolutePath);
        /// <summary>
        /// Get sum for payment entries, each file format will implement this method
        /// </summary>
        /// <param name="paymentEntries"></param>
        /// <returns></returns>
        public abstract float GetPaymentEntrySum(List<string> paymentEntries);
    }
}

