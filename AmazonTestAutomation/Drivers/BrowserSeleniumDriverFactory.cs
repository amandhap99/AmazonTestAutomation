using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Safari;
using TechTalk.SpecFlow;
using System.Drawing;
using OpenQA.Selenium.Remote;

namespace AmazonTestAutomation.Drivers
{
    public class BrowserSeleniumDriverFactory
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly FeatureContext _featureContext;
        private readonly Size _windowSize;
        private Dictionary<string, object> _sauceOptions;
        private Uri _seleniumHubUri;

        public BrowserSeleniumDriverFactory(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;
            _windowSize = new Size(1920, 1080);
            _seleniumHubUri = new Uri("https://ondemand.saucelabs.com/wd/hub");
        }

        public IWebDriver GetForBrowser(string browserId)
        {
            string upperCaseBrowserId = browserId.ToUpper();
            switch (Environment.GetEnvironmentVariable("RunInSauceLabs"))
            {
                case "true":
                    SetSauceOptions();
                    break;
                case "false": break;
                default: throw new NotSupportedException("You have selected an option other than true or false for RunInSauceLabs in run settings");
            }
            switch (upperCaseBrowserId)
            {
                case "INTERNET EXPLORER": return GetInternetExplorerDriver();
                case "MICROSOFTEDGE": return GetEdgeDriver();
                case "CHROME": return GetChromeDriver();
                case "FIREFOX": return GetFirefoxDriver();
                case "SAFARI": return GetSafariDriver();
                case string browserString: throw new NotSupportedException($"{browserString} is not a supported browser");
                default: throw new NotSupportedException("not supported browser: <null>");
            }
        }


        private void SetSauceOptions()
        {
            var dictionaryValues = _scenarioContext.ScenarioInfo.Arguments;
            var test = string.Join("|", dictionaryValues.Values.Cast<String>().ToList());
            _sauceOptions = new Dictionary<string, object>
            {
                { "name", $"{_featureContext.FeatureInfo.Title} - {_scenarioContext.ScenarioInfo.Title} - {test}" },
                { "username", Environment.GetEnvironmentVariable("SAUCE_USERNAME") },
                { "build", Environment.GetEnvironmentVariable("BuildName") },
                { "accessKey", Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY") },
                { "screenResolution", Environment.GetEnvironmentVariable("SauceLabsResolution") }
            };
        }

        private IWebDriver GetFirefoxDriver()
        {
            var firefoxOptions = new FirefoxOptions();
            firefoxOptions.AcceptInsecureCertificates = true;
            if (bool.Parse(Environment.GetEnvironmentVariable("RunInSauceLabs")))
            {
                firefoxOptions.BrowserVersion = Environment.GetEnvironmentVariable("Test_Browser_Version");
                firefoxOptions.PlatformName = Environment.GetEnvironmentVariable("OperatingSystem");
                firefoxOptions.AddAdditionalOption("sauce:options", _sauceOptions);
                return new RemoteWebDriver(_seleniumHubUri, firefoxOptions);
            }
            else return new FirefoxDriver(firefoxOptions);
        }

        private IWebDriver GetChromeDriver()
        {
            var chromeOptions = new ChromeOptions();
            if (bool.Parse(Environment.GetEnvironmentVariable("RunInSauceLabs")))
            {
                chromeOptions.BrowserVersion = Environment.GetEnvironmentVariable("Test_Browser_Version");
                chromeOptions.PlatformName = Environment.GetEnvironmentVariable("OperatingSystem");
                chromeOptions.AddAdditionalOption("sauce:options", _sauceOptions);
                return new RemoteWebDriver(_seleniumHubUri, chromeOptions);
            }
            else return new ChromeDriver(chromeOptions);
        }

        private IWebDriver GetInternetExplorerDriver()
        {
            var internetExplorerOptions = new InternetExplorerOptions
            {
                IgnoreZoomLevel = true,
            };

            if (bool.Parse(Environment.GetEnvironmentVariable("RunInSauceLabs")))
            {
                internetExplorerOptions.BrowserVersion = Environment.GetEnvironmentVariable("Test_Browser_Version");
                internetExplorerOptions.PlatformName = Environment.GetEnvironmentVariable("OperatingSystem");
                internetExplorerOptions.AddAdditionalOption("sauce:options", _sauceOptions);
                return new RemoteWebDriver(_seleniumHubUri, internetExplorerOptions);
            }
            else return new InternetExplorerDriver(internetExplorerOptions);
        }

        private IWebDriver GetEdgeDriver()
        {
            var edgeOptions = new EdgeOptions();

            if (bool.Parse(Environment.GetEnvironmentVariable("RunInSauceLabs")))
            {
                edgeOptions.BrowserVersion = Environment.GetEnvironmentVariable("Test_Browser_Version");
                edgeOptions.PlatformName = Environment.GetEnvironmentVariable("OperatingSystem");
                edgeOptions.AddAdditionalOption("sauce:options", _sauceOptions);
                return new RemoteWebDriver(_seleniumHubUri, edgeOptions);
            }
            else return new EdgeDriver(edgeOptions);

        }
        private IWebDriver GetSafariDriver()
        {
            var safariOptions = new SafariOptions();

            if (bool.Parse(Environment.GetEnvironmentVariable("RunInSauceLabs")))
            {
                safariOptions.BrowserVersion = Environment.GetEnvironmentVariable("Test_Browser_Version");
                safariOptions.PlatformName = Environment.GetEnvironmentVariable("OperatingSystem");
                safariOptions.AddAdditionalOption("sauce:options", _sauceOptions);
                return new RemoteWebDriver(_seleniumHubUri, safariOptions);
            }
            else throw new NotSupportedException("Local safari has not been supported on windows 10 ");

        }
    }
}
