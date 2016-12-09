using HtmlAgilityPack;

namespace HtmlHelpers.Processor
{
    public interface IHtmlProcessor
    {
        void ProcessNodeCollection(HtmlNodeCollection rawData);
    }
}
