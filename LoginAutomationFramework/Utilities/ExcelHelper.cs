using ClosedXML.Excel;
using LoginAutomationFramework.Models;

namespace LoginAutomationFramework.Utilities
{
    public class ExcelHelper
    {
        private static readonly string filePath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            "TestData",
            "LoginData.xlsx");

        public static LoginDataModel GetLoginData(string testCase)
        {
            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet("LoginData");

                for (int row = 2; row <= worksheet.LastRowUsed().RowNumber(); row++)
                {
                    string currentTestCase =
                        worksheet.Cell(row, 1).GetString().Trim();

                    if (currentTestCase.Equals(testCase,
                        StringComparison.OrdinalIgnoreCase))
                    {
                        return new LoginDataModel
                        {
                            Email = worksheet.Cell(row, 2).GetString(),
                            Password = worksheet.Cell(row, 3).GetString()
                        };
                    }
                }

                throw new Exception($"Test Case '{testCase}' not found.");
            }
        }
    }
}