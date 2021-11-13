using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Politrip_TestSuite.Base;
using System;

using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace Politrip_TestSuite
{
    [TestClass]
    public class UnitTest1 : TestBase
    {
        [TestMethod]
        [TestCategory("Accounts")]
        public void CreateAccountAlreadyExistingTest()
        {
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(25);
            IWebElement FirstName = browser.FindElement(By.XPath("//div/input[@formcontrolname='firstName' and @placeholder='Joane']"));
            FirstName.SendKeys("Vasile");            // By.Id("first-name");

            IJavaScriptExecutor js = (IJavaScriptExecutor)browser;
            js.ExecuteScript("window.scrollBy(0,70)");

            IWebElement LastName = browser.FindElement(By.XPath("//input[@name='last-name' and @placeholder='Smith']"));
            LastName.SendKeys("Balaceanu");
            //browser.FindElement(By.XPath("//input[@name='last-name'][@placeholder='Smith']")).SendKeys("Balaceanu");

            IWebElement Email = browser.FindElement(By.Id("email"));
            Email.SendKeys("vasile.balaceanu98@gmail.com");

            IWebElement Password = browser.FindElement(By.Id("sign-up-password-input"));
            Password.SendKeys("HeavenSolution2021");


            IWebElement ConfirmPassword = browser.FindElement(By.Id("sign-up-confirm-password-input"));
            ConfirmPassword.SendKeys("HeavenSolution2021");

            SelectElement HearAboutUp = new SelectElement(browser.FindElement(By.Id("sign-up-heard-input")));
            foreach (IWebElement myOption in HearAboutUp.Options)
            {
                if (myOption.Text == "Social networks") // choose from dropdown
                { myOption.Click(); }
            }

            IWebElement SignUpBtn = browser.FindElement(By.XPath("//div/button[@id=' qa_loader-button' and @type='submit']"));
            SignUpBtn.Click();

            String ActualmMessage = browser.FindElement(By.Id("sign-up-error-div")).Text;
            String ExpectedMessage = "An user with this email is already registered";

            Assert.AreEqual(ActualmMessage, ExpectedMessage);
            //Assert.IsTrue(ActualmMessage.Contains("An user with this email is already registered"));
        }


        [TestMethod]
        [TestCategory("Buttons")]
        public void HomeButtonTest()
        {
            IWebElement HomeBtn = browser.FindElement(By.XPath("//ul/li/a/span[@class='label'][1]"));
            HomeBtn.Click();

            string ExpectedResult = "https://politrip.com/";
            string ActualResult = browser.Url.ToString();

            Assert.AreEqual(ExpectedResult, ActualResult);

        }


        [TestMethod]
        [TestCategory("Accounts")]
        public void AlreadyHaveAccountLinkTest()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)browser;
            js.ExecuteScript("window.scrollBy(0,750)");
            Thread.Sleep(5000);

            IWebElement AlreadyAccountBtn = browser.FindElement(By.XPath("//a/span[text()='Already have an account?']"));
            AlreadyAccountBtn.Click();

            string ExpectedResult = "https://politrip.com/account/login";
            string ActualResult = browser.Url.ToString();

            Assert.AreEqual(ExpectedResult, ActualResult);

        }


        [TestMethod]
        [TestCategory("Buttons")]
        public void HowItWorksButtonTest()
        {
            IWebElement HowWorksBtn = browser.FindElement(By.Id("qa_header-how-it-works"));
            HowWorksBtn.Click();

            string ExpectedResult = "https://politrip.com/how-it-works";
            string ActualResult = browser.Url.ToString();

            Assert.AreEqual(ExpectedResult, ActualResult);
        }


        [TestMethod]
        [TestCategory("Buttons")]
        public void LogInButtonTest()
        {
            IWebElement LogInBtn = browser.FindElement(By.Id("qa_header-login"));
            LogInBtn.Click();

            string ExpectedResult = "https://politrip.com/account/login";
            string ActualResult = browser.Url.ToString();

            Assert.AreEqual(ExpectedResult, ActualResult);
        }


        [TestMethod]
        [TestCategory("Buttons")]
        public void LogoImgGoHomeTest()
        {
            IWebElement LogoImg = browser.FindElement(By.Id("qa_header-logo"));
            LogoImg.Click();

            string ExpectedResult = "https://politrip.com/";
            string ActualResult = browser.Url.ToString();

            Assert.AreEqual(ExpectedResult, ActualResult);
        }


        [TestMethod]
        [TestCategory("Accounts")]
        public void LessValuePasswordTest()
        {
            IWebElement FirstName = browser.FindElement(By.XPath("//div/input[@formcontrolname='firstName' and @placeholder='Joane']"));
            FirstName.SendKeys("Vasile");            // By.Id("first-name");

            IJavaScriptExecutor js = (IJavaScriptExecutor)browser;
            js.ExecuteScript("window.scrollBy(0,100)");

            IWebElement LastName = browser.FindElement(By.XPath("//input[@name='last-name' and @placeholder='Smith']"));
            LastName.SendKeys("Balaceanu");
            //browser.FindElement(By.XPath("//input[@name='last-name'][@placeholder='Smith']")).SendKeys("Balaceanu");

            IWebElement Email = browser.FindElement(By.Id("email"));
            Email.SendKeys("vasile.balaceanu98@gmail.com");

            IWebElement Password = browser.FindElement(By.Id("sign-up-password-input"));
            Password.SendKeys("password");

            IWebElement ConfirmPassword = browser.FindElement(By.XPath("//input[@placeholder='Repeat your password' and @name='password']"));
            ConfirmPassword.SendKeys("password");

            IWebElement WrongPasswordMsg = browser.FindElement(By.XPath("//span[text()=' Password must contain at least 8 characters, 1 uppercase letter, 1 lowercase letter and 1 digit ']"));

            string ExpectedResult = "Password must contain at least 8 characters, 1 uppercase letter, 1 lowercase letter and 1 digit";
            string ActualResult = WrongPasswordMsg.Text;

            Assert.IsTrue(ActualResult.Contains(ExpectedResult));
        }


        [TestMethod]
        [TestCategory("Accounts")]
        public void SignUpBtnMissingRequiredFieldsTest()
        {
            IWebElement FirstName = browser.FindElement(By.XPath("//div/input[@formcontrolname='firstName' and @placeholder='Joane']"));
            FirstName.SendKeys("Vasile");            // By.Id("first-name");

            IWebElement LastName = browser.FindElement(By.XPath("//input[@name='last-name' and @placeholder='Smith']"));
            LastName.SendKeys("Balaceanu");
            //browser.FindElement(By.XPath("//input[@name='last-name'][@placeholder='Smith']")).SendKeys("Balaceanu");

            IJavaScriptExecutor js = (IJavaScriptExecutor)browser;
            js.ExecuteScript("window.scrollBy(0,400)");

            IWebElement ConfirmPassword = browser.FindElement(By.Id("sign-up-confirm-password-input"));
            ConfirmPassword.SendKeys("HeavenSolution2021");

            // IWebElement SignUpBtn = browser.FindElement(By.XPath("//span[@class='button-label' and text()=' Sign up ']"));
            IWebElement SignUpBtn = browser.FindElement(By.XPath("//button[@id=' qa_loader-button']"));

            string SignUpBtnClass = SignUpBtn.GetAttribute("class");

            if (SignUpBtnClass == "button pol-button-style no-click-on-disabled")
            {
                Assert.IsTrue(false); // button is enabled if we write in all required fields
            }
            else if (SignUpBtnClass == "button pol-button-style disabled-button no-click-on-disabled" || SignUpBtnClass == "button pol-button-style no-click-on-disabled disabled-button")
            {
                Assert.IsTrue(true); // button is disabled and this is ok because I did not write in required fields
            }
        }

        [TestMethod]
        [TestCategory("Accounts")]
        public void WrongEmailTest()
        {
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(25);
            IWebElement FirstName = browser.FindElement(By.XPath("//div/input[@formcontrolname='firstName' and @placeholder='Joane']"));
            FirstName.SendKeys("Vasile");            // By.Id("first-name");

            IWebElement LastName = browser.FindElement(By.XPath("//input[@name='last-name' and @placeholder='Smith']"));
            LastName.SendKeys("Balaceanu");
            //browser.FindElement(By.XPath("//input[@name='last-name'][@placeholder='Smith']")).SendKeys("Balaceanu");

            IJavaScriptExecutor js = (IJavaScriptExecutor)browser;
            js.ExecuteScript("window.scrollBy(0,375)");

            IWebElement Email = browser.FindElement(By.Id("email"));

            Random rand = new Random();
            int r = rand.Next(1, 10000);
            Email.SendKeys(r.ToString()+"@test");

            IWebElement Password = browser.FindElement(By.Id("sign-up-password-input"));
            Password.SendKeys("HeavenSolution2021");

            IWebElement ConfirmPassword = browser.FindElement(By.Id("sign-up-confirm-password-input"));
            ConfirmPassword.SendKeys("HeavenSolution2021");

            IWebElement Email2 = browser.FindElement(By.Id("email"));
            string EmailContent = Email2.GetAttribute("value");

            try { EmailContent = EmailContent.Substring(EmailContent.LastIndexOf("@")); } catch { }

            IWebElement SignUpBtn = browser.FindElement(By.XPath("//button[@id=' qa_loader-button']"));

            string SignUpBtnClass = SignUpBtn.GetAttribute("class");

            if (SignUpBtnClass == "button pol-button-style no-click-on-disabled") // button is enabled even the email is wrong format
            {
                Assert.IsTrue(EmailContent.Contains(".") && EmailContent.Contains("@"));
            }
        }


        [TestMethod]
        [TestCategory("Accounts")]
        public void CreateAccountWrongEmailTest()
        {
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(25);
            IWebElement FirstName = browser.FindElement(By.XPath("//div/input[@formcontrolname='firstName' and @placeholder='Joane']"));
            FirstName.SendKeys("Vasile");            // By.Id("first-name");

            IWebElement LastName = browser.FindElement(By.XPath("//input[@name='last-name' and @placeholder='Smith']"));
            LastName.SendKeys("Balaceanu");
            //browser.FindElement(By.XPath("//input[@name='last-name'][@placeholder='Smith']")).SendKeys("Balaceanu");

            IJavaScriptExecutor js = (IJavaScriptExecutor)browser;
            js.ExecuteScript("window.scrollBy(0,375)");

            IWebElement Email = browser.FindElement(By.Id("email"));

            Random rand = new Random();
            int r = rand.Next(1, 10000);
            Email.SendKeys(r.ToString() + "@test");

            IWebElement Password = browser.FindElement(By.Id("sign-up-password-input"));
            Password.SendKeys("HeavenSolution2021");

            IWebElement ConfirmPassword = browser.FindElement(By.Id("sign-up-confirm-password-input"));
            ConfirmPassword.SendKeys("HeavenSolution2021");


            IWebElement SignUpBtn = browser.FindElement(By.XPath("//button[@id=' qa_loader-button']"));

            string SignUpBtnClass = SignUpBtn.GetAttribute("class");

            if (SignUpBtnClass == "button pol-button-style no-click-on-disabled") // button is enabled
            {
                SignUpBtn.Click();
                browser.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);

                Thread.Sleep(4000);

                js.ExecuteScript("window.scrollBy(0,350)");

                IWebElement PersonTypeBtn = browser.FindElement(By.XPath("//div/div[@class['choose-container participant-container'] and @id='qa_signup-participant']"));
                PersonTypeBtn.Click();

                browser.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);

                IWebElement MyIcon = browser.FindElement(By.XPath("//button/span[@class='profile-icon']"));

                Thread.Sleep(2000);

                Actions Action = new Actions(browser);
                Action.MoveToElement(MyIcon).Build().Perform();

                Thread.Sleep(2000);

                IWebElement LogOutBtn = browser.FindElement(By.XPath("//span[@class='label' and text()=' Log out ']"));
                Assert.IsTrue(LogOutBtn.Displayed == false);
                //Log out button is displayed, this means that we successfully created a new account with a wrong email
                //I tested the display of Log out button because it could go to home page, without to create a new account, because the wrong email
                //Also I made this test because the Sign Up button could be Enabled but generate an error when clicking on it
            }
        }


        [TestMethod]
        [TestCategory("Accounts")]
        public void PasswordMatchRequiredTest()
        {
            IWebElement Password = browser.FindElement(By.Id("sign-up-password-input"));
            Password.SendKeys("HeavenSolution2021");

            IWebElement ConfirmPassword = browser.FindElement(By.Id("sign-up-confirm-password-input"));
            ConfirmPassword.SendKeys("HeavenSolution202");

            IWebElement Email = browser.FindElement(By.Id("email"));
            Email.SendKeys("Hello@gmail");

            IWebElement PassMustMathError = browser.FindElement(By.XPath("//em/span[text()=' Passwords must match ']"));
            Assert.IsTrue(PassMustMathError.Displayed);

        }
    }
}

