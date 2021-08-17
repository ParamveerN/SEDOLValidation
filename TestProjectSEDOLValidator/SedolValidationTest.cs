using NUnit.Framework;
using System.Collections.Generic;
using SEDOLValidators;
using System;

namespace TestProjectSEDOLValidator
{
    [TestFixture]
    public class Tests
    {

        [Test, TestCaseSource("SedolTestData")]
        public void TestSedolValidator(string SedolNumber, bool IsValidSdeol, bool IsUserDefined, string ValidationDetails)
        {
            ISedolValidationResult validateResult = new ValidationResult();
            Validator validator = new Validator();
            validateResult = validator.ValidateSedol(SedolNumber);
            Assert.True(IsValidSdeol.Equals(validateResult.IsValidSedol));
            Assert.True(IsUserDefined.Equals(validateResult.IsUserDefined));
            Assert.True(String.Equals(ValidationDetails, validateResult.ValidationDetails, StringComparison.OrdinalIgnoreCase));
        }

        private static IEnumerable<TestCaseData> SedolTestData()
        {
            yield return new TestCaseData(null, false, false, "Input string was not 7-characters long").
                SetName("Null | False | False | Input string was not 7-characters long");

            yield return new TestCaseData("", false, false, "Input string was not 7-characters long").
                SetName(" | False | False | Input string was not 7-characters long");

            yield return new TestCaseData("12", false, false, "Input string was not 7-characters long").
                SetName(" 12 | False | False | Input string was not 7-characters long");

            yield return new TestCaseData("123456789", false, false, "Input string was not 7-characters long").
                SetName(" 123456789 | False | False | Input string was not 7-characters long");

            yield return new TestCaseData("1234567", true, false, "Checksum digit does not agree with the rest of the input").
                SetName(" 1234567 | True | False | Checksum digit does not agree with the rest of the input");

            yield return new TestCaseData("0709954", true, false, null).
                SetName(" 0709954 | True | False | Null");

            yield return new TestCaseData("B0YBKJ7", true, false, null).
                SetName(" B0YBKJ7 | True | False | Null");

            yield return new TestCaseData("9123451", true, true, "Checksum digit does not agree with the rest of the input").
                SetName(" 9123451 | True | True | Checksum digit does not agree with the rest of the input");

            yield return new TestCaseData("9ABCDE8", true, true, "Checksum digit does not agree with the rest of the input").
                SetName(" 9ABCDE8 | True | True | Checksum digit does not agree with the rest of the input");

            yield return new TestCaseData("9123_51", false, false, "SEDOL contains invalid characters").
                SetName(" 9123_51 | False | False | SEDOL contains invalid characters");

            yield return new TestCaseData("VA.CDE8", true, true, "SEDOL contains invalid characters").
                SetName(" VA.CDE8 | False | False | SEDOL contains invalid characters");

            yield return new TestCaseData("9123458", true, true, null).
                SetName(" 9123458 | True | True | Null");

            yield return new TestCaseData("9ABCDE1", true, true, null).
                SetName(" 9ABCDE1 | True | True | Null");

        }
    }
}