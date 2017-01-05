using HtmlHelpers.HtmlParser;
using HtmlHelpers.Processor;
using NLog;
using SimpleInjector;

namespace Engine.Unity
{
    public class EngineUnityContainer
    {
        private readonly Container _container;

        public EngineUnityContainer(Container container)
        {
            _container = container;
        }

        public void Resolve()
        {
            _container.Register<IHtmlProcessor, HtmlTipsterProcessor>();
            _container.Register<IHtmlParser, HtmlAgilityParser>();
            _container.Register<StartEngine.StartEngine>();
            _container.Register<ILogger>(() => LogManager.GetCurrentClassLogger(), Lifestyle.Singleton);
            _container.Verify();
        }
    }
}
