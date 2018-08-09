using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaxTechnicalTraining.Bootcamp.DotNet.TestDrivenDevelopment;

namespace TestCases {

	class Program {
		static void Main(string[] args) {
			bool allTestsPassed = TestForZeroInputs();
			allTestsPassed &= TestForOneInput();
			allTestsPassed &= TestForValidInputs();
			allTestsPassed &= TestForMoreThanTenInputs();

			if(allTestsPassed) {
				Console.WriteLine("All tests passed.");
			} else {
				Console.WriteLine("Some tests failed.");
			}
			Console.ReadKey();
		}
		static bool TestForValidInputs() {
			string userInput = "3, 5";
			Calculator calculator = new Calculator();
			int sum = calculator.Add(userInput);
			bool passed = PrintTestResult("3", "Test for valid inputs", "8", sum.ToString());
			userInput = "9, 21";
			sum = calculator.Add(userInput);
			passed &= PrintTestResult("4", "Test for valid inputs", "30", sum.ToString());
			// three inputs
			userInput = "3, 8, 12";
			sum = calculator.Add(userInput);
			passed &= PrintTestResult("5", "Test for valid inputs", "23", sum.ToString());

			userInput = "9, 21, 10";
			sum = calculator.Add(userInput);
			passed &= PrintTestResult("6", "Test for valid inputs", "40", sum.ToString());

			userInput = "5542, 4237, 4040";
			sum = calculator.Add(userInput);
			passed &= PrintTestResult("7", "Test for valid inputs", "13819", sum.ToString());
			// 4
			userInput = "4,	3,	1,	8";
			sum = calculator.Add(userInput);
			passed &= PrintTestResult("8", "Test for valid inputs", "16", sum.ToString());
			// 5
			userInput = "1,	7,	1,	1,	6";
			sum = calculator.Add(userInput);
			passed &= PrintTestResult("9", "Test for valid inputs", "16", sum.ToString());
			// 6
			userInput = "8,	3,	9,	4,	3,	1";
			sum = calculator.Add(userInput);
			passed &= PrintTestResult("10", "Test for valid inputs", "28", sum.ToString());
			// 7
			userInput = "8,	1,	2,	6,	9,	3,	8";
			sum = calculator.Add(userInput);
			passed &= PrintTestResult("11", "Test for valid inputs", "37", sum.ToString());
			// 8
			userInput = "1,	4,	4,	7,	10,	2,	7,	10";
			sum = calculator.Add(userInput);
			passed &= PrintTestResult("12", "Test for valid inputs", "45", sum.ToString());
			// 9
			userInput = "9,	8,	5,	2,	6,	7,	1,	3,	8";
			sum = calculator.Add(userInput);
			passed &= PrintTestResult("13", "Test for valid inputs", "49", sum.ToString());
			// 10
			userInput = "9,	5,	10,	4,	3,	0,	3,	0,	1,	9";
			sum = calculator.Add(userInput);
			passed &= PrintTestResult("14", "Test for valid inputs", "44", sum.ToString());

			return passed;
		}
		static bool TestForMoreThanTenInputs() {
			string userInput = "1,1,1,1,1,1,1,1,1,1,1";
			string ApplicationExceptionThrown = "No Exception";
			Calculator calculator = new Calculator();
			try {
				// should throw an ApplicationException
				calculator.Add(userInput);
			} catch (ApplicationException ex) {
				ApplicationExceptionThrown = "ApplicationException";
			}
			bool passed = PrintTestResult("15", "Test for more than ten inputs", "ApplicationException", ApplicationExceptionThrown);
			return passed;
		}
		static bool TestForOneInput() {
			string userInput = "100";
			string ApplicationExceptionThrown = "No Exception";
			Calculator calculator = new Calculator();
			try {
				// should throw an ApplicationException
				calculator.Add(userInput);
			} catch (ApplicationException ex) {
				ApplicationExceptionThrown = "ApplicationException";
			}
			bool passed = PrintTestResult("2", "Test for one input", "ApplicationException", ApplicationExceptionThrown);
			return passed;
		}
		static bool TestForZeroInputs() {
			string userInput = "";
			string ApplicationExceptionThrown = "No Exception";
			Calculator calculator = new Calculator();
			try {
				// should throw an ApplicationException
				calculator.Add(userInput);
			} catch (ApplicationException ex) {
				ApplicationExceptionThrown = "ApplicationException";
			}
			bool passed = PrintTestResult("1", "Test for zero inputs", "ApplicationException", ApplicationExceptionThrown);
			return passed;
		}
		static bool PrintTestResult(string Id, string Description, string ExpectedResults, string ActualResults) {
			string passfail = ExpectedResults == ActualResults ? "PASS" : "FAIL";
			Console.WriteLine($"{Id} {Description} {ExpectedResults} {ActualResults} {passfail}");
			return passfail == "PASS";
		}
	}
}
