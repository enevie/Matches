using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HtmlHelpers.Selenium
{
    public class Selenium
    {
        private readonly IWebDriver _driver;

        public Selenium()
        {
            _driver = new ChromeDriver();
        }

        public string GetPageSource(string url)
        {
            _driver.Url = url;
            var source = _driver.PageSource;
            _driver.Close();
            return source;
        }
    }
}
