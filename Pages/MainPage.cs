using OpenQA.Selenium;



namespace SinopticBgTests.Pages
{
    public class MainPage : BasePage
    {

        public MainPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement Cookies => Driver.FindElement(By.Id("didomi-notice-agree-button"));
        public IWebElement SearchField => Driver.FindElement(By.Id("searchField"));
        public IWebElement City => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(Driver.FindElement(By.XPath("//*[@class='autocomplete']"))));
        public IWebElement CurrentCity => Driver.FindElement(By.XPath("//h1[@class='currentCity']"));
        public IWebElement TenDaysForecast => Driver.FindElement(By.XPath("//a[contains(text(),'5-дневна')]"));
        public IList<IWebElement> DayOfWeek => Driver.FindElements(By.XPath("//span[@class='wf10dayRightDay']"));
        public IList<IWebElement> ActualDate => Driver.FindElements(By.XPath("//span[@class='wf10dayRightDate']"));


        public void Navigate()
        {
            Driver.Url = "https://www.sinoptik.bg";
        }

    }

}

