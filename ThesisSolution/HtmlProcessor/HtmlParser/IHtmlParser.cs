using HtmlAgilityPack;

namespace HtmlHelpers.HtmlParser
{
    public interface IHtmlParser
    {
        HtmlNodeCollection ParseHtml(string url);
    }
}
                                                                   