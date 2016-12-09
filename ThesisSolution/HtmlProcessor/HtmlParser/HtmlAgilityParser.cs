using HtmlAgilityPack;

namespace HtmlHelpers.HtmlParser
{
    public class HtmlAgilityParser : IHtmlParser
    {
        private readonly Selenium.Selenium _selenium;

        public HtmlAgilityParser(Selenium.Selenium selenium)
        {
            _selenium = selenium;
        }

        public HtmlNodeCollection ParseHtml(string url)
        {
            var rawDoc = _selenium.GetPageSource(url);
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(rawDoc);

            return doc.DocumentNode.SelectNodes("//*[contains(@class,'tr')]");
        }
    }
}
