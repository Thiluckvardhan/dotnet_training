using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace OrangeHRMSAutomation
{
    public class LoginTest
    {
        IWebDriver? driver;
        AventStack.ExtentReports.ExtentReports? extent;
        ExtentTest? test;

        [OneTimeSetUp]
        public void SetupReporting()
        {
            var sparkReporter = new ExtentSparkReporter("TestReport.html");
            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(sparkReporter);
        }

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
        }

        [Test]
        public void LoginToOrangeHRMS()
        {
            test = extent!.CreateTest("Login Test").Info("Test Started");

            try
            {
                // Define a wait period (e.g., 10 seconds)
                WebDriverWait wait = new WebDriverWait(driver!, TimeSpan.FromSeconds(10));

                // Wait until the username field is visible before interacting
                IWebElement usernameField = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("username")));

                usernameField.SendKeys("Admin");
                driver!.FindElement(By.Name("password")).SendKeys("admin123");
                driver.FindElement(By.CssSelector("button[type='submit']")).Click();

                // Wait for the dashboard to load to confirm success
                wait.Until(ExpectedConditions.UrlContains("dashboard"));

                Assert.That(driver.Url, Does.Contain("dashboard"));
                test.Pass("Login successful");
            }
            catch (Exception ex)
            {
                test.Fail("Test failed: " + ex.Message);
                throw;
            }
        }

        [TearDown]
        public void EndTest()
        {
            // Safely close and dispose the WebDriver
            try
            {
                driver?.Quit();
            }
            finally
            {
                driver?.Dispose();
                driver = null;
            }
        }

        [OneTimeTearDown]
        public void GenerateReport()
        {
            extent?.Flush();
        }
    }
}