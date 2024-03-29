﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;


namespace SeleniumTests
{
    
    [TestFixture]
    public class Test
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()

        {
            driver= new FirefoxDriver();
            baseURL = "https://phptravels.com/";
            driver.Manage().Window.Maximize();
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/hotels-module-features/");
            Assert.AreEqual("Hotels module features", driver.FindElement(By.Id("header-title")).Text);
            Assert.AreEqual("Complete Hotels Booking Module", driver.FindElement(By.XPath("//div[@id='UA-container']/div/div/div/div/div/h2")).Text);
            Assert.AreEqual("Full Calendar", driver.FindElement(By.XPath("//div[@id='UA-container']/div/div[2]/div/div/div[2]/h2")).Text);
            driver.FindElement(By.LinkText("View Pricing")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.CssSelector("h4")).Click();
            driver.FindElement(By.XPath("(//label[@id='label']/h4)[2]")).Click();
            driver.FindElement(By.XPath("(//label[@id='label']/h4)[3]")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }


    
}


