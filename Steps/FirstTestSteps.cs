using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Steps
{
    [Binding]
    public sealed class FirstTestSteps
    {
        private static IWebDriver _driver;

        public FirstTestSteps(IWebDriver driver)
        {
            _driver = driver;
        }

        [Given(@"I go to the ""(.*)"" website")]
        public void NavigateToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Window.Maximize();
        }

        [When(@"I click on the Sign In button")]
        public void ClickSignIn()
        {
            IWebElement element = _driver.FindElement(By.CssSelector("#primary-menu > li.sign-in-link.hide-xs.hide-sm > a"));
            element.Click();
        }

        [Then(@"I should see the Sign In page")]
        public void SignIn()
        {
            Assert.AreEqual("https://www.browserstack.com/users/sign_in", _driver.Url);
        }

        [AfterTestRun]
        public static void TearDown()
        {
            _driver.Quit();
        }
    }
}
