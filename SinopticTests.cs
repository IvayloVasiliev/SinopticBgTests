using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using SinopticBgTests.Extensions;
using SinopticBgTests.Pages;
using SinopticBgTests.Tests;
using System.Globalization;

namespace SinopticBgTests
{
    [TestFixture]
    public class SinopticTests : BaseTest
    {
        //private ChromeDriver _driver;
        private MainPage _mainPage;

        [SetUp]
        public void Setup()
        {

            _mainPage = new MainPage(Driver);
        }

        [Test]
        public void DaysForecast()
        {
            _mainPage.Navigate();
            _mainPage.Cookies.Click();

            //Search Кюстендил and select it from the dropdown
            _mainPage.SearchField.Type("Кюстендил");
            _mainPage.City.Click();

            // Verify the correct forecast is loaded
            Assert.That(_mainPage.CurrentCity.Text, Is.EqualTo("Кюстендил"));
            ElementExtensions.HighlightElement(_mainPage.CurrentCity, Driver);

            //Go to the 10 day forecast 
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", _mainPage.TenDaysForecast);
            _mainPage.TenDaysForecast.Click();

            //verify the days of week and dates are correct
            DateTime todayDate = DateTime.Now;

            for (int i = 0; i < _mainPage.ActualDate.Count; i++)
            {
                DateTime newDate = todayDate.AddDays(i);

                String expectedDate = newDate.ToString("dd.MM.yy", CultureInfo.InvariantCulture);
                String expectedDayOfWeek = newDate.ToString("ddd.", CultureInfo.CreateSpecificCulture("bg-BG"));
                String actualDayOfWeek = _mainPage.DayOfWeek[i].Text.ToLower();

                Assert.True(_mainPage.ActualDate[i].Text.Equals(expectedDate));
                Assert.True(actualDayOfWeek.Contains(expectedDayOfWeek));
            }
        }

        [TearDown]
        public void CleanUp()
        {
            var name = TestContext.CurrentContext.Test.Name;
            var result = TestContext.CurrentContext.Result.Outcome;

            if (result != ResultState.Success)
            {
                Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                var fullPath = Path.GetFullPath("..\\..\\..\\ScreenShots\\");
                screenshot.SaveAsFile(fullPath + name + ".png");
                //screenshot.SaveAsFile("screenshot.png");
            }



        }
    }
}