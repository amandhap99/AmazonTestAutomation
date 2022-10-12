using AmazonTestAutomation.Pages;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using NUnit.Framework;

namespace AmazonTestAutomation.StepDefinitionFiles
{
    [Binding]
    class LoginSteps
    {
        private readonly AmazonLoginPage _amazonLoginPage;


        public LoginSteps(AmazonLoginPage amazonLoginPage)
        {
            _amazonLoginPage = amazonLoginPage;
        }

        [Given(@"user launch the amazon web page")]
        public void GivenUserLaunchTheAmazonWebPage()
        {
            _amazonLoginPage.NavigateToClientWeb();
        }

        [Given(@"user click on '(.*)' button")]
        public void GivenUserClickOnButton(string p0)
        {
            _amazonLoginPage.ClickSignInlink();
        }

        [Then(@"user should see sign in user id page details")]
        public void ThenUserShouldSeeSignInUserIdPageDetails()
        {
            _amazonLoginPage.IsSignInUserIdPageExist();
        }

        [When(@"user enter email id into user id field")]
        public void WhenUserEnterEmailIdIntoUserIdField(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _amazonLoginPage.EnterUserId(data.EMail);
        }

        [When(@"user click on '(.*)' button")]
        public void WhenUserClickOnButton(string p0)
        {
            _amazonLoginPage.ClickContinueButton();
        }

        [Then(@"user should see sign in password page details")]
        public void ThenUserShouldSeeSignInPasswordPageDetails()
        {
            _amazonLoginPage.IsSignInPasswordPageExist();
        }

        [When(@"user enter password into the field")]
        public void WhenUserEnterPasswordIntoTheField(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _amazonLoginPage.EnterPassword(data.Password);
        }

        [When(@"user click on sign in button")]
        public void WhenUserClickOnSignInButton()
        {
            _amazonLoginPage.ClickSignInButton();
        }


        [Then(@"user should see amazon home page details")]
        public void ThenUserShouldSeeAmazonHomePageDetails()
        {
            _amazonLoginPage.IsLoginSuccessful();
        }      
    }
}

