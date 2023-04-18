using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HospitalTests.HospitalE2ETests.Pages.Public
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        public const string URI = "http://localhost:4200/auth/login";

        private IWebElement UsernameElement => _driver.FindElement(By.Name("username"));
        private IWebElement PasswordElement => _driver.FindElement(By.Name("password"));
        private IWebElement SubmitButtonElement => _driver.FindElement(By.Name("submit"));

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public bool UsernameElementDisplayed()
        {
            return UsernameElement.Displayed;
        }

        public bool PasswordElementDisplayed()
        {
            return PasswordElement.Displayed;
        }

        public bool SubmitButtonElementDisplayed()
        {
            return SubmitButtonElement.Displayed;
        }

        public void InsertUsername(string username)
        {
            UsernameElement.SendKeys(username);
        }

        public void InsertPassword(string password)
        {
            PasswordElement.SendKeys(password);
        }

        public void Login()
        {
            SubmitButtonElement.Click();
        }

        public void WaitForLogin()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe(HomePage.URI));
        }
    }
}
