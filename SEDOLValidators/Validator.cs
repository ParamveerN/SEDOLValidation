using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace SEDOLValidators
{
    public class Validator : ISedolValidator
    {
        #region Global variables
        public int[] sedol_weights = { 1, 3, 1, 7, 3, 9 };

        public int sedol_Valid_Length = 7;

        public char sedol_user_defined_char = '9';

        public string message = string.Empty;

        #endregion

        #region Validation Level 3
        /// <summary>
        /// Validates Sedol length
        /// </summary>
        /// <param name="Sedol"></param>
        /// <returns></returns>
        public Boolean IsValidCheckLength(string Sedol)
        {
            int len = Sedol.Length;

            if (len != sedol_Valid_Length)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Validates Sedol format
        /// </summary>
        /// <param name="Sedol"></param>
        /// <returns></returns>
        public Boolean IsValidSedolFormat(string Sedol)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(Sedol, "[^A-Za-z0-9]"))
                return false;
            else
                return true;
        }

        /// <summary>
        /// Validates Sedol User Defined
        /// </summary>
        /// <param name="Sedol"></param>
        /// <returns></returns>
        public Boolean IsUserDefined(string Sedol)
        {
            if (Sedol[0] == sedol_user_defined_char)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Validates Sedol Check Sum
        /// </summary>
        /// <param name="Sedol"></param>
        /// <returns></returns>
        public Boolean IsValidCheckDigit(string Sedol)
        {
            int sum = 0;

            for (int i = 0; i < 6; i++)
            {
                if (Char.IsDigit(Sedol[i]))
                    sum += (((int)Sedol[i] - 48) * sedol_weights[i]);

                else if (Char.IsLetter(Sedol[i]))
                    sum += (((int)Char.ToUpper(Sedol[i]) - 55) * sedol_weights[i]);

                else
                    sum = -1;
            }

            int digitSum = (10 - (sum % 10)) % 10;

            int checkDigit = Convert.ToInt32(Regex.Match(Sedol, @"(.{1})\s*$").ToString());

            if (checkDigit == digitSum)
                return true;
            else
                return false;

        }

        #endregion

        #region Validation Level 2
        protected string ValidateSedolFormat(string Sedol)
        {

            if (string.IsNullOrEmpty(Sedol))
                return "Input string was not 7-characters long";
            if (!IsValidCheckLength(Sedol))
                return "Input string was not 7-characters long";
            if (!IsValidSedolFormat(Sedol))
                return "SEDOL contains invalid characters";
            else
                return null;
        }

        protected string CheckIfUserDefined(string Sedol)
        {
            if (!IsUserDefined(Sedol))
                return "Checksum digit does not agree with the rest of the input";
            else
                return null;
        }

        protected string CheckDigitValidated(string Sedol)
        {
            if (!IsValidCheckDigit(Sedol))
                return "Checksum digit does not agree with the rest of the input";
            else
                return null;

        }

        #endregion

        #region Validation Level 1
        /// <summary>
        /// Validates Sedol Length, format, provides if user defined and validates check sum matches to Sum Weight of the six character
        /// </summary>
        /// <param name="Sedol"></param>
        /// <returns></returns>
        public ISedolValidationResult ValidateSedol(string Sedol)
        {
            ValidationResult sedolValidationResult = new ValidationResult();

            sedolValidationResult.InputString = Sedol;
            sedolValidationResult.ValidationDetails = ValidateSedolFormat(Sedol); // Validate Sedol and get validation message

            // Validation messsage null denotes Sedol is valid and we can process further
            if (string.IsNullOrEmpty(sedolValidationResult.ValidationDetails))
            {
                // Sedol has correct length and correct format.
                sedolValidationResult.IsValidSedol = true;
            }
            else
            {
                // Sedol doesnt has correct length and correct format.
                sedolValidationResult.IsValidSedol = false;
                return sedolValidationResult;
            }

            //Validate if Sedol is User Defines
            sedolValidationResult.ValidationDetails = CheckIfUserDefined(Sedol);

            // Validation message null denotes Sedol is User Defined
            if (string.IsNullOrEmpty(sedolValidationResult.ValidationDetails))
            {
                sedolValidationResult.IsUserDefined = true;
            }
            else
            {
                sedolValidationResult.IsUserDefined = false;
            }

            // When Sedol is Valid then checksum validation should be executed.
            if (sedolValidationResult.IsValidSedol)
            {
                sedolValidationResult.ValidationDetails = CheckDigitValidated(Sedol); // Validate if CheckSum is valid
            }

            return sedolValidationResult;
        }
        #endregion

    }
}
