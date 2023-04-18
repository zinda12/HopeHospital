using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HospitalTests.HospitalE2ETests.Pages.Public
{
    public class HomePage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:4200/home";

        private IWebElement LoginLink => driver.FindElement(By.Id("login"));
        private IWebElement AddFeedbackLink => driver.FindElement(By.Id("createFeedback"));
        private IWebElement ViewAppointmentsLink => driver.FindElement(By.Id("appointments"));

        public bool LoginLinkDisplayed()
        {
            return LoginLink.Displayed;
        }
        public bool AddFeedbackLinkDisplayed()
        {
            return AddFeedbackLink.Displayed;
        }
        public bool ViewAppointmentsLinkDisplayed()
        {
            return ViewAppointmentsLink.Displayed;
        }
        public void ClickLoginLink()
        {
            LoginLink.Click();
        }
        public void ClickAddFeedbackLink()
        {
            AddFeedbackLink.Click();
        }
        public void ClickViewAppointmentsLink()
        {
            ViewAppointmentsLink.Click();
        }
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);

    }
}
