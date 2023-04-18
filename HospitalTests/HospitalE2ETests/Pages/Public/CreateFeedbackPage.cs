using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalTests.HospitalE2ETests.Pages.Public
{
    public class CreateFeedbackPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:4200/createFeedback";

        private IWebElement FeedbackTextElement => driver.FindElement(By.Name("text"));
        private IWebElement IsPublicElement => driver.FindElement(By.Name("isPublic"));
        private IWebElement IsAnonymousElement => driver.FindElement(By.Name("isAnonymous"));
        private IWebElement SubmitButtonElement => driver.FindElement(By.Name("submit"));
        private IWebElement ValidMessageElement => driver.FindElement(By.Id("feedbackError"));

        public const string ValidSubmitMessage = "Feedback is created";

        public bool FeedbackTextElementDisplayed()
        {
            return FeedbackTextElement.Displayed;
        }
        public bool ValidMessageElementDisplayed()
        {
            return ValidMessageElement.Displayed;
        }
        public bool IsPublicElementDisplayed()
        {
            return IsPublicElement.Displayed;
        }

        public bool IsAnonymousElementDisplyed()
        {
            return IsAnonymousElement.Displayed;
        }

        public bool SubmitButtonElementDisplayed()
        {
            return SubmitButtonElement.Displayed;
        }

        public void InsertFeedbackText(string text)
        {
            FeedbackTextElement.SendKeys(text);
        }

        public void ClickIsPublic()
        {
            IsPublicElement.Click();
        }
        public void ClickIsAnonymous()
        {
            IsAnonymousElement.Click();
        }

        public void ClickSubmitButton()
        {
            SubmitButtonElement.Click();
        }

        public bool GetSubmitButtonState()
        {
            return SubmitButtonElement.Enabled;
        }

        public string GetValidMessageFromElement()
        {
            return ValidMessageElement.Text;
        }

        public string GetValidMessage()
        {
            return ValidSubmitMessage;
        }

        public CreateFeedbackPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}
