using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;


namespace SinopticBgTests.Pages
{
    public abstract class BasePage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));

        }

        public IWebDriver Driver => _driver;
        public WebDriverWait Wait => _wait;


        public virtual void Navigate(string url)
        {
            Driver.Url = url;
        }

    }
}
