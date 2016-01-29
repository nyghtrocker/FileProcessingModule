using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileProcessingModule.Interfaces
{
    public interface IPaymentService
    {
        /// <summary>
        /// Get all the files 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="targetDirectory"></param>
        /// <returns></returns>
        List<string> GetFiles(string fileName, string targetDirectory);
        /// <summary>
        /// Get opening entry from file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        string GetOpeningEntry(string filePath);
        /// <summary>
        /// Get all the payment entries from file
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        List<string> GetPaymentEntries(string filepath);
        /// <summary>
        /// Get path for the folder where files are located
        /// </summary>
        /// <param name="baseDirectory"></param>
        /// <param name="relativePath"></param>
        /// <returns></returns>
        string GetFullPath(string baseDirectory, string relativePath);
        /// <summary>
        /// Validate the files data and call to IPaymentReceiver
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="absolutePath"></param>
        /// <returns></returns>
        string FileProcessing(string filePath, string absolutePath);
        /// <summary>
        /// Validate the string value
        /// </summary>
        /// <param name="valueToValidate"></param>
        /// <returns></returns>
        bool ValidateStringValue(string valueToValidate);
        /// <summary>
        /// Validate the Int value, for ex. validate the account number
        /// </summary>
        /// <param name="valueToValidate"></param>
        /// <returns></returns>
        bool ValidateIntegerValue(string valueToValidate);
        /// <summary>
        /// Validate the field with fixed value
        /// </summary>
        /// <param name="fixedValue"></param>
        /// <param name="valueToValidate"></param>
        /// <returns></returns>
        bool ValidateWidthFixedValue(string fixedValue,  string valueToValidate);
        /// <summary>
        /// Validate the file amount in opening or payment entries
        /// </summary>
        /// <param name="value"></param>
        /// <param name="valueToValidate"></param>
        /// <returns></returns>
        bool ValidateAmount(string value, string valueToValidate);
        /// <summary>
        /// Get sum of all the payment entries in the file
        /// </summary>
        /// <param name="paymentEntries"></param>
        /// <returns></returns>
       float GetPaymentEntrySum(List<string> paymentEntries);
        /// <summary>
        /// Get the substring from the string
        /// </summary>
        /// <param name="originalString"></param>
        /// <param name="startValue"></param>
        /// <param name="EndValue"></param>
        /// <returns></returns>
        string  GetSubString(string originalString, int startValue, int EndValue);
    }
}
