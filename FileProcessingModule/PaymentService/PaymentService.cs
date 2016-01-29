using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileProcessingModule.PaymentService
{
   public  class PaymentService
    {
        AlphaPaymentService alphaService; 
        BetaPaymentService betaService;  
        private string baseDirectory;
        const string relativePath = @"..\\FileProcessingModule\FileProcessingModule\PaymentServiceFiles";
        string absolutePath;      
       public PaymentService()
        {
           alphaService = new AlphaPaymentService();
           betaService = new BetaPaymentService();
           baseDirectory = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName);
           absolutePath = Path.GetFullPath(baseDirectory + relativePath);
        }
       public string  Main( string fileName)
       {
           if(fileName.Contains("_alphapayment"))
           {

               return alphaService.FileProcessing(@"*_alphapayment.txt", absolutePath);
           }
           else if (fileName.Contains("_betapayment"))
           {

               return betaService.FileProcessing(@"*_betapayment.txt", absolutePath);
           }         
           return "Not valid file name";
       }
    }
}


