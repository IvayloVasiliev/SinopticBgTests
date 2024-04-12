using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SinopticBgTests.Tests
{
    [TestFixture]
    public class BaseTest
    {

        public IWebDriver Driver { get; private set; }

        [OneTimeSetUp]
        public void InitilizeTests()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            options.AddArgument("--disable-notifications");
            options.AddUserProfilePreference("disable-popup-blocking", "true");
            //Driver = new ChromeDriver((@"C:\\Users\\ivail\\Desktop\\chromedriver-win64"), options);
            Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);
        }

        [OneTimeTearDown]
        public void CleanUp()
        { 
            Driver.Quit(); 
        }   

    }
}
