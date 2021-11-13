using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Politrip_TestSuite.Base
{
    [TestClass]
    public class TestBase
    {
        public ChromeDriver browser;
        public string baseURL = "https://politrip.com/account/sign-up";



        [TestInitialize]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-notifications");

            browser = new ChromeDriver(options);
            browser.Manage().Window.Maximize();
            browser.Navigate().GoToUrl(baseURL); // open application

            IWebElement AcceptCookiesBtn = browser.FindElement(By.Id("cookiescript_accept"));
            AcceptCookiesBtn.Click();
        }


        [TestCleanup]
        public void Cleanup()
        {
            browser.Close(); //close browser
        }

    }
}
