using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AmazonTestAutomation.Utilities
{
    class ElementWaitFunctions
    {

        public static void WaitUntilClickableThenClick(IWebDriver driver, IWebElement element, int timeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(timeoutInSeconds));
            _ = wait.Until(ExpectedConditions.ElementToBeClickable(element));
            element.Click();
        }

        public static void WaitUntilTextDoesNotContain(IWebDriver driver, By locator, string textValue, int timeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(timeoutInSeconds));
            _ = wait.Until(d => !(driver.FindElement(locator).Text.Trim().Contains(textValue)));
        }

        public static void WaitUntilAttributeContains(IWebDriver driver, By locator, string attributeName, string attributeValue, int timeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(timeoutInSeconds));
            _ = wait.Until(d => driver.FindElement(locator).GetAttribute(attributeName).Equals(attributeValue));
        }
        public static void WaitUntilAttributeNotNull(IWebDriver driver, By locator, string attributeName, int timeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(timeoutInSeconds));
            _ = wait.Until(d => driver.FindElement(locator).GetAttribute(attributeName) != null);
        }

        public static IWebElement GetElementOnceVisable(IWebDriver driver, By locator, int timeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(timeoutInSeconds));
            _ = wait.Until(ExpectedConditions.ElementIsVisible(locator));
            return driver.FindElement(locator);
        }


        public static void WaitForURL(IWebDriver driver, string url, int timeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(timeoutInSeconds));
            _ = wait.Until(ExpectedConditions.UrlToBe(url));

        }
    }
}
