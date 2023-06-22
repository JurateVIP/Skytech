using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Skytech
{
    public class Main
    {
        static IWebDriver driver;
        static GeneralMethods generalMethods;
        SearchField searchField;


        [SetUp]
        public void SetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-notifications");
            driver = new ChromeDriver(options);
            generalMethods = new GeneralMethods(driver);
            searchField = new SearchField(driver);

            driver.Manage().Window.Maximize();
            driver.Url = "https://www.skytech.lt/";

        }

        [Test]
        public void SearchBox()
        {
            searchField.SentTextToSearch("iPhone 14");
            searchField.OrSearchContainsSearchableName("iPhone", "14");
        }


        [TearDown]
        public static void CloseWindow()
        {
            driver.Quit();
        }


    }

}