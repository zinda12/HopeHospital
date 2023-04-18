using HospitalTests.HospitalE2ETests.Pages.Public;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Shouldly;


namespace HospitalTests.HospitalE2ETests.FeedbackTests
{
    public class CreateFeedbackTest : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly HomePage _homePage;
        private readonly LoginPage _loginPage;
        private readonly CreateFeedbackPage _createFeedbackPage;

        public CreateFeedbackTest()
        {
            var options = CreateChromeOptions();

            _driver = new ChromeDriver(options);

            _homePage = new HomePage(_driver);
            _homePage.Navigate();
            _homePage.LoginLinkDisplayed().ShouldBe(true);
            _homePage.ClickLoginLink();

            _loginPage = new LoginPage(_driver);
            _driver.Url.ShouldBe(LoginPage.URI);
            _loginPage.UsernameElementDisplayed().ShouldBe(true);
            _loginPage.PasswordElementDisplayed().ShouldBe(true);
            _loginPage.SubmitButtonElementDisplayed().ShouldBe(true);
            Login();

            _driver.Url.ShouldBe(HomePage.URI);
            _homePage.ClickAddFeedbackLink();

            _createFeedbackPage = new CreateFeedbackPage(_driver);
            _driver.Url.ShouldBe(CreateFeedbackPage.URI);
            _createFeedbackPage.FeedbackTextElementDisplayed().ShouldBe(true);
            _createFeedbackPage.IsPublicElementDisplayed().ShouldBe(true);
            _createFeedbackPage.IsAnonymousElementDisplyed().ShouldBe(true);
            _createFeedbackPage.SubmitButtonElementDisplayed().ShouldBe(true);


        }
        private void Login()
        {
            _loginPage.InsertUsername("patient");
            _loginPage.InsertPassword("12345");
            _loginPage.Login();

            _loginPage.WaitForLogin();
        }

        private static ChromeOptions CreateChromeOptions()
        {
            // options for launching Google Chrome
            var options = new ChromeOptions();
            options.AddArguments("start-maximized"); // open Browser in maximized mode
            options.AddArguments("disable-infobars"); // disabling infobars
            options.AddArguments("--disable-extensions"); // disabling extensions
            options.AddArguments("--disable-gpu"); // applicable to windows os only
            options.AddArguments("--disable-dev-shm-usage"); // overcome limited resource problems
            options.AddArguments("--no-sandbox"); // Bypass OS security model
            options.AddArguments("--disable-notifications"); // disable notifications

            return options;
        }

        [Fact]
        public void InvalidFeedbackTextShowsErrorMessage()
        {
            _createFeedbackPage.InsertFeedbackText("");
            _createFeedbackPage.ClickIsPublic();
            _createFeedbackPage.ClickIsAnonymous();
            Assert.False(_createFeedbackPage.GetSubmitButtonState());

        }

        [Fact]
        public void Valid()
        {
            _createFeedbackPage.InsertFeedbackText("Bolnica je odlicna");
            _createFeedbackPage.ClickIsPublic();
            _createFeedbackPage.ClickSubmitButton();
            Assert.True(_createFeedbackPage.GetSubmitButtonState());
            _createFeedbackPage.ValidMessageElementDisplayed().ShouldBe(true);
            Assert.Equal(_createFeedbackPage.GetValidMessage(), _createFeedbackPage.GetValidMessageFromElement());
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
