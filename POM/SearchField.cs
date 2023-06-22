using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;

namespace Skytech
{
    internal class SearchField
    {
        DefaultWait<IWebDriver> wait;
        GeneralMethods generalMethods;

        public SearchField(IWebDriver driver)
        {
            generalMethods = new GeneralMethods(driver);
            wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(10);
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        }
        public void SentTextToSearch(string text)
        {
            generalMethods.EnterTextByXpath("//input[@class='search-field inactive']", text);
            generalMethods.ClickElementByXpath("//input[@class='search-button']");
        }
        public void OrSearchContainsSearchableName(string text1, string text2)
        {
            generalMethods.ClickElementByXpath("//a[@class='v0 sf-with-ul']");
            generalMethods.ClickElementByXpath("//a[@class='v2']");
            Thread.Sleep(1000);
            IReadOnlyCollection<IWebElement> searchResults = generalMethods.FindAllElementsByXpath("//tr[contains(@class,'productListing')]");
            List<string> resulte = searchResults.Select(result => result.Text).ToList();

            foreach (var res in resulte)
            {
                bool containText1 = res.Contains(text1);
                bool containText2 = res.Contains(text2);

                if (!containText1 && !containText2)
                {
                    Console.WriteLine(res);
                    Console.WriteLine("This product has no searchable name.");
                }
            }
        }


    }
}