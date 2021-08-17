# SEDOL
SEDOL Validation project Assignment

Project has been developed with .Net Core 3.1 

1. DemoProject is the App to execute function created for Sedol validation, Which also has dummy data mentioned in assignment.
1.1   In order to run the project and see output DemoProject can be selected as Default project >> Run >> Console Application will open >> Which will have printed results.
1.2   To add/remove/update dummy data on Demo Project Program.cs is the location to update.

2. SEDOLValidatiors is the project created as Class Library where We have incorporated result interface
2.1 In ortder to use validation in other classes in future we create sperate function based on validation level.
2.2 ISedolValidationResult validateResult = new ValidationResult();
            Validator validator = new Validator();
            validateResult = validator.ValidateSedol(SedolNumber);
     Above code snippet can be use for using function.
     
3. TestProjectSEDOLValidator is created for Unit test
3.1 SedolValidationTest.cs is the location where unit test case has been written
3.2 private static IEnumerable<TestCaseData> SedolTestData() is the test data routine where we can change test data as per required
3.3 All test cased mentioned in Assignment has been added in test data, In order to run all test executed Test >> Run All
