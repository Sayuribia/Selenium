using System.Runtime.Serialization;
using System.Security.AccessControl;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System.Collections.Generic;
using System.Linq;

namespace Selenium{
    class Comandos {

 #region Browser
            public static IWebDriver GetBrowserLocal(IWebDriver driver, String browser) 
            {
                switch (browser)
                {
                    case "Internet Explorer":
                    driver = new InternetExplorerDriver();
                    driver.Manage().Window.Maximize();
                    break;
                    case "Chrome":
                    driver = new ChromeDriver();
                    driver.Manage().Window.Maximize();
                    break;
                    default:
                    driver = new FirefoxDriver();
                    driver.Manage().Window.Maximize();
                    break;
                    
                }

                return driver;
            }

#endregion Browser
             /*   public static void ExecuteJS(IWebDriver driver, String script)
                {
                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                    JsonFormatGeneratorStatics.ExecuteScrit(script);
                }*/

                 public static IWebDriver GetBrowserRemote(IWebDriver driver, String browser, String Uri) 
                 {
            switch (browser)
                {
                    case "Internet Explorer":
                    InternetExplorerOptions cap_ie = new InternetExplorerOptions();
                    driver = new RemoteWebDriver(new Uri(Uri), cap_ie);
                    driver.Manage().Window.Maximize();
                    break;

                    case "Chrome":    
                    ChromeOptions cap_chrome = new ChromeOptions();
                    driver = new RemoteWebDriver(new Uri(Uri), cap_chrome);
                    driver.Manage().Window.Maximize();
                    break;

                    default:
                    FirefoxOptions cap_firefox = new FirefoxOptions();                    
                    driver = new RemoteWebDriver(new Uri(Uri), cap_firefox);
                    driver.Manage().Window.Maximize();
                    break;
                    
                    
                }

                return driver;
            }

    }


}