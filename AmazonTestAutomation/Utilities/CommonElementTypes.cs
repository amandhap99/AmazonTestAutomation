using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace AmazonTestAutomation.Utilities
{
    class CommonElementTypes
    {
        public enum SelectBy { Index, Text, Value };
        public static void SelectElement(IWebElement selectElement, string selectChoice, SelectBy selectBy)
        {
            var selectBox = new SelectElement(selectElement);
            switch (selectBy)
            {
                case SelectBy.Index:
                    try
                    {
                        var selectIndex = Convert.ToInt32(selectChoice);
                        selectBox.SelectByIndex(selectIndex);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"{selectChoice} is not a sequence of digits. When using SelectBy.Index input selectChoice needs to be an integer");
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("The number cannot fit in an Int32.");
                    }
                    break;
                case SelectBy.Text:
                    selectBox.SelectByText(selectChoice);
                    break;
                case SelectBy.Value:
                    selectBox.SelectByValue(selectChoice);
                    break;

            }
        }

        public static void ToggleElement(IWebDriver driver, string toggleText, bool toggleTo)
        {
            var toggleElements = driver.FindElements(By.XPath($"//span[text()='{toggleText}']/preceding-sibling::div//child::*"));
            foreach (IWebElement element in toggleElements)
            {
                var ariaChecked = element.GetAttribute("aria-checked")?.ToString();
                var toggle = toggleTo.ToString().ToLower();

                if (ariaChecked != null && ariaChecked != toggle)
                {
                    toggleElements[1].Click();
                }

            }
        }

        public static IWebElement GetElementInTableBodyByCoordinates(IWebDriver driver, int row, int column)
        {
            return driver.FindElement(By.XPath($"//tbody/tr[{row}]/td[{column}]"));
        }

        public static int GetNumberOfRowsInTable(IWebDriver driver, int tableIndexDom)
        {
            return driver.FindElements(By.XPath($"//tbody[{tableIndexDom}]/tr")).Count;
        }
    }
}