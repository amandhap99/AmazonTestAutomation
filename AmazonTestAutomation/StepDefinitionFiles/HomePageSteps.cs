using AmazonTestAutomation.Pages;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using NUnit.Framework;

namespace AmazonTestAutomation.StepDefinitionFiles
{
    [Binding]
    class HomePageSteps
    {
        private readonly AmazonHomePage _amazonHomePage;

        public HomePageSteps(AmazonHomePage amazonHomePage)
        {
            _amazonHomePage = amazonHomePage;
        }

        [Given(@"user enter product details in search field '(.*)'")]
        public void GivenUserEnterProductDetailsInSearchField(string itemName)
        {
            _amazonHomePage.EnterItemNameInSearchBar(itemName);
        }

        [Given(@"user click on search button")]
        public void GivenUserClickOnSearchButton()
        {
            _amazonHomePage.ClickSearchButton();
        }

        [Then(@"user should see search results related to item name")]
        public void ThenUserShouldSeeSearchResultsRelatedToItemName()
        {
            _amazonHomePage.IsSearchResultsExist();
        }

        [When(@"user click on the category link")]
        public void WhenUserClickOnTheCategoryLink()
        {
            _amazonHomePage.ClickMensCategoryLink();
        }

        [When(@"user click on the selected item")]
        public void WhenUserClickOnTheSelectedItem()
        {
            _amazonHomePage.ClickItemDescLink();
        }

        [When(@"user selects the size of the socks")]
        public void WhenUserSelectsTheSizeOfTheSocks()
        {
            _amazonHomePage.ClickSizeDropdownButtton();
            _amazonHomePage.SelectSize();
        }

        [When(@"user click on add to cart button")]
        public void WhenUserClickOnAddToCartButton()
        {
            _amazonHomePage.ClickAddToCartButton();
        }

        [When(@"user click on proceed to checkout button")]
        public void WhenUserClickOnProceedToCheckoutButton()
        {
            _amazonHomePage.ClickProceedToCheckoutButton();
        }

        [Then(@"user should see checkout page details")]
        public void ThenUserShouldSeeCheckoutPageDetails()
        {
            _amazonHomePage.IsCheckoutPageExist();
        }

        [When(@"user click on use this payment method button")]
        public void WhenUserClickOnUseThisPaymentMethodButton()
        {
            _amazonHomePage.ClickUseThisPaymentMethodButton();
        }

        [Then(@"Then user should see place your order button")]
        public void ThenThenUserShouldSeePlaceYourOrderButton()
        {
            _amazonHomePage.IsPlaceYourOrderButtonExist();
        }
    }
}
