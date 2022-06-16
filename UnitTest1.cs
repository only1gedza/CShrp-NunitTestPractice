using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Reflection;

namespace SeleniumCore
{
    [TestClass]
    public class HomepageFeature
    {
        IWebDriver driver;

        [TestMethod]
        public void ShouldBeAbleToLogin()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            driver = new ChromeDriver(outPutDirectory);
            driver.Navigate().GoToUrl("https://www.saucedemo.com");

            var loginButtonLocator = By.Id("login-button");

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(loginButtonLocator));

            var userNameField = driver.FindElement(By.Id("user-name"));
            var passwordField = driver.FindElement(By.Id("password"));
            var loginButton = driver.FindElement(loginButtonLocator);

            userNameField.SendKeys("standard_user");
            passwordField.SendKeys("secret_sauce");
            loginButton.Click();

            Assert.IsTrue(driver.Url.Contains("inventory.html"));

        }
        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }

    }
}