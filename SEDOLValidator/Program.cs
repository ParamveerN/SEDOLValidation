using SEDOLValidators;
using System;
using System.Collections.Generic;

namespace SEDOLValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executing SEDOL Check Digit ...");

            Validator validtor = new Validator();
            // Testing data from provided format
            List<string> input = new List<string>() {
                "9123458",
                "7108899",
                null,
                "12",
                "",
                "123456789",
                "1234567",
                "0709954",
                "B0YBKJ7",
                "9123451",
                "9ABCDE8",
                "9123_51",
                "VA.CDE8",
                "9123458",
                "9ABCDE1",
                "7108899",
            };

            // Calling Sedol Validation and priniting
            foreach(String strInput in input)
            {
                ValidationResult validationResult = (ValidationResult)validtor.ValidateSedol(strInput);
                Console.WriteLine("Check Sum Sedol for Input (" + strInput + " ) : " + "" + validationResult.InputString +  "|" + validationResult.IsValidSedol + "|" + validationResult.IsUserDefined + "|" + validationResult.ValidationDetails);
            }            
        }  
    }
}
