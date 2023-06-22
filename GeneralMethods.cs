using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Skytech
{
    internal class GeneralMethods
    {
        IWebDriver driver;
        DefaultWait<IWebDriver> wait;
        public GeneralMethods(IWebDriver driver)
        {
            this.driver = driver;
            wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(10);
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        }
        public void ClickElementByXpath(string xpath)
        {
            IWebElement element = wait.Until(x => x.FindElement(By.XPath(xpath)));
            element.Click();
        }
        public void ClickElementById(string id)
        {
            IWebElement element = wait.Until(x => x.FindElement(By.Id(id)));
            element.Click();
        }
        public void ScrollAndClickElementByXpath(string xpath)
        {
            IWebElement element = wait.Until(x => x.FindElement(By.XPath(xpath)));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            element.Click();
        }
        public void ScrollAndClickElementByID(string id)
        {
            IWebElement element = wait.Until(x => x.FindElement(By.Id(id)));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            element.Click();
        }
        public void EnterTextById(string id, string text)
        {
            IWebElement element = wait.Until(x => x.FindElement(By.Id(id)));
            element.SendKeys(text);
        }
        public void EnterTextByXpath(string xpath, string text)
        {
            IWebElement element = wait.Until(x => x.FindElement(By.XPath(xpath)));
            element.SendKeys(text);
        }
        public IReadOnlyCollection<IWebElement> FindAllElementsByXpath(string xpath)
        {
            IReadOnlyCollection<IWebElement> element = wait.Until(x => x.FindElements(By.XPath(xpath)));
            return element;
        }
        public void TakeScreenShot()
        {
            Screenshot ss = driver.TakeScreenshot();
            string screenshot = "screenshot" + DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss") + ".jpg";
            ss.SaveAsFile("..\\Screenshots\\" + screenshot);
        }
    }
}