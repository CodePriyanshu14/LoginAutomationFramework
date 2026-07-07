using LoginAutomationFramework.Drivers;
using OpenQA.Selenium;

namespace LoginAutomationFramework.Utilities
{
    public class ScreenshotHelper
    {
        public static void CaptureScreenshot(string fileName)
        {
            Screenshot screenshot =
                ((ITakesScreenshot)DriverFactory.GetDriver()).GetScreenshot();

            string folderPath = @"C:\Users\priyanshu.m\source\repos\LoginAutomationFramework\LoginAutomationFramework\Screenshot";

            //if (!Directory.Exists(folderPath))
            //{
            //    Directory.CreateDirectory(folderPath);
            //}

            string filePath = Path.Combine(
                folderPath,
                fileName + ".png");

            screenshot.SaveAsFile(filePath);
        }
    }
}