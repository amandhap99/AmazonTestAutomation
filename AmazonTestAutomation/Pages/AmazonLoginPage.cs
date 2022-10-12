using OpenQA.Selenium;
using AmazonTestAutomation.Utilities;
using NUnit.Framework;
using System.Threading;
using AmazonTestAutomation.Drivers;
using System;
using OpenQA.Selenium.Support.UI;

namespace AmazonTestAutomation.Pages
{
    class AmazonLoginPage
    {
        private const int TimeoutInSeconds = 30;
        private readonly IWebDriver driver;
        public AmazonLoginPage(Drivers.WebDriver webdriver)
        {
            driver = webdriver.Current;
        }

        //public readonly IWebDriver driver;

        // UI Elements
        private By byAmazonHomePageHeader => By.XPath("//a[@id='nav-logo-sprites']");
        private IWebElement lnkSignIn => driver.FindElement(By.XPath("//a[@id='nav-link-accountList']"), TimeoutInSeconds);
        private By bylabelSignInUserIdPage => By.XPath("//label[contains(text(),'Email or mobile phone number')]");
        private IWebElement emailTextBox => driver.FindElement(By.XPath("//input[@id='ap_email']"), TimeoutInSeconds);
        private IWebElement btnContinue => driver.FindElement(By.Id("continue"), TimeoutInSeconds);
        private By bylabelSignInPasswordPage => By.XPath("//label[contains(text(),'Password')]");
        private IWebElement passwordTextBox => driver.FindElement(By.XPath("//input[@id='ap_password']"), TimeoutInSeconds);
        private IWebElement btnsignIn => driver.FindElement(By.Id("signInSubmit"), TimeoutInSeconds);
        private By txtLoginConfirmation => By.XPath("//span[contains(text(),'Hello, Rajesh')]");



        public void NavigateToClientWeb()
        {
            driver.Navigate().GoToUrl(Environment.GetEnvironmentVariable("ClientWebAppUrl"));
        }

        public bool IsAmazonHomePageExist()
        {
            var homePageHeader = ElementWaitFunctions.GetElementOnceVisable(driver, byAmazonHomePageHeader, TimeoutInSeconds);
            return homePageHeader.Displayed;
        }

        public void ClickSignInlink() => lnkSignIn.Click();

        public bool IsSignInUserIdPageExist()
        {
            var userIdPageHeader = ElementWaitFunctions.GetElementOnceVisable(driver, bylabelSignInUserIdPage, TimeoutInSeconds);
            return userIdPageHeader.Displayed;
        }                

        public void EnterUserId(string email)
        {
            emailTextBox.SendKeys(email);
        }

        public void ClickContinueButton() => btnContinue.Click();

        public bool IsSignInPasswordPageExist()
        {
            var passwordPageHeader = ElementWaitFunctions.GetElementOnceVisable(driver, bylabelSignInPasswordPage, TimeoutInSeconds);
            return passwordPageHeader.Displayed;
        }

        public void EnterPassword(string password)
        {
            passwordTextBox.SendKeys(password);
        }

        public void ClickSignInButton() => btnsignIn.Click();

        public bool IsLoginSuccessful()
        {
            var loginConfirmationText = ElementWaitFunctions.GetElementOnceVisable(driver, txtLoginConfirmation, TimeoutInSeconds);
            return loginConfirmationText.Displayed;
        }

        //public void SignInEnvironmentUser(string user, string password)
        //{
        //    var email = EnvironmentInjection.AddEnvironmentToUser(user);
        //    SignIn(email, password);
        //}
    }
}
