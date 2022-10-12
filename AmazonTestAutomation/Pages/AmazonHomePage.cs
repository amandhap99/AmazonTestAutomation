using OpenQA.Selenium;
using AmazonTestAutomation.Utilities;
using NUnit.Framework;
using System.Threading;
using AmazonTestAutomation.Drivers;
using System;
using OpenQA.Selenium.Support.UI;

namespace AmazonTestAutomation.Pages
{
    class AmazonHomePage
    {
        private const int TimeoutInSeconds = 30;
        private readonly IWebDriver driver;
        public AmazonHomePage(Drivers.WebDriver webdriver)
        {
            driver = webdriver.Current;
        }

        //public readonly IWebDriver driver;

        // UI Elements
        private IWebElement txtSearchBar => driver.FindElement(By.XPath("//input[@id='twotabsearchtextbox']"), TimeoutInSeconds);
        private IWebElement btnSearch => driver.FindElement(By.XPath("//input[@id='nav-search-submit-button']"), TimeoutInSeconds);
        private IWebElement lnkMens => driver.FindElement(By.LinkText("Men's"), TimeoutInSeconds);
        private IWebElement lnkItemDesc => driver.FindElement(By.LinkText("Men's Max Cushion Crew Socks, Available in 6 and 12-Pair Pack"), TimeoutInSeconds);
        private IWebElement btnSizeDropdown => driver.FindElement(By.XPath("//span[@id='dropdown_selected_size_name']"), TimeoutInSeconds);
        private IWebElement selectSize => driver.FindElement(By.XPath("//a[@id='native_dropdown_selected_size_name_1']"), TimeoutInSeconds);
        private IWebElement btnAddToCart => driver.FindElement(By.XPath("//button[contains(text(),' Add to Cart ')]"), TimeoutInSeconds);
        private IWebElement lnkCart => driver.FindElement(By.XPath("//span[@id='nav-cart-count']"), TimeoutInSeconds);
        private IWebElement btnProceedToCheckOut => driver.FindElement(By.Name("proceedToRetailCheckout"), TimeoutInSeconds);
        private By byCheckoutPageheader => By.XPath("//h1[contains(text(),'Checkout')]");
        private IWebElement btnUseThisPaymentMethod => driver.FindElement(By.XPath("//input[contains(@aria-labelledby, 'orderSummaryPrimaryActionBtn-announce')]"), TimeoutInSeconds);
        private IWebElement btnPlaceYourOrder => driver.FindElement(By.XPath("(//span[contains(text(),'Place your order')])[1]"), TimeoutInSeconds);


        //UI Methods

        public void EnterItemNameInSearchBar(string itemName)
        {
            txtSearchBar.SendKeys(itemName);
        }

        public void ClickSearchButton() => btnSearch.Click();

        public void IsSearchResultsExist()
        {
            Assert.IsTrue(lnkItemDesc.Displayed);
        }

        public void ClickMensCategoryLink() => lnkMens.Click();

        public void ClickItemDescLink() => lnkItemDesc.Click();
        public void ClickSizeDropdownButtton() => btnSizeDropdown.Click();

        public void SelectSize()
        {
            selectSize.Click();
            Thread.Sleep(1000);
        }

        public void ClickAddToCartButton()
        {
            btnAddToCart.Click();
            lnkCart.Click();
        }

        public void ClickProceedToCheckoutButton()
        {
            btnProceedToCheckOut.Click();
            Thread.Sleep(1000);
        }

        public bool IsCheckoutPageExist()
        {
            var checkoutPageHeader = ElementWaitFunctions.GetElementOnceVisable(driver, byCheckoutPageheader, TimeoutInSeconds);
            return checkoutPageHeader.Displayed;
        }

        public void ClickUseThisPaymentMethodButton()
        {
             btnUseThisPaymentMethod.Click();
            Thread.Sleep(4000);
        }

        public void IsPlaceYourOrderButtonExist()
        {
            Assert.IsTrue(btnPlaceYourOrder.Displayed);
        }
        public void ClickPlaceYourOrderButton() => btnPlaceYourOrder.Click();
    }
}
