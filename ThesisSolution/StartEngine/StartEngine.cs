using HtmlHelpers.HtmlParser;
using HtmlHelpers.Processor;

namespace StartEngine
{
    public class StartEngine
    {
        private readonly IHtmlParser _parser;
        private readonly IHtmlProcessor _htmlProcessor;
        private const string Url = "http://tipster.bg/";

        public StartEngine(IHtmlParser parser, IHtmlProcessor htmlProcessor)
        {
            _parser = parser;
            _htmlProcessor = htmlProcessor;
        }

        public void Run()
        {
            var games = _parser.ParseHtml(Url);
            _htmlProcessor.ProcessNodeCollection(games);
        }
    }
}
