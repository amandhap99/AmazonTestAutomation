using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonTestAutomation.Drivers
{
    public class WebDriver : IDisposable
    {
        private readonly BrowserSeleniumDriverFactory _browserSeleniumDriverFactory;
        private readonly Lazy<IWebDriver> _currentWebDriverLazy;
        private bool _isDisposed;

        public WebDriver(BrowserSeleniumDriverFactory browserSeleniumDriverFactory)
        {
            _browserSeleniumDriverFactory = browserSeleniumDriverFactory;
            _currentWebDriverLazy = new Lazy<IWebDriver>(GetWebDriver);
        }

        public IWebDriver Current => _currentWebDriverLazy.Value;

        private IWebDriver GetWebDriver()
        {
            string testBrowserId = Environment.GetEnvironmentVariable("Test_Browser");
            var driver = _browserSeleniumDriverFactory.GetForBrowser(testBrowserId);
            driver.Manage().Window.Maximize();
            return driver;
        }

        public void Dispose()
        {

            if (_isDisposed)
            {
                return;
            }

            if (_currentWebDriverLazy.IsValueCreated)
            {
                Current.Quit();
            }

            _isDisposed = true;
        }
    }
}
