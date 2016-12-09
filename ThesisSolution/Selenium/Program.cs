using DataAccessLayer.Unity;
using Engine.Unity;
using SimpleInjector;

namespace Program
{
    public class Program
    {
        static void Main(string[] args)
        {
            var container = new Container();
            var dataUnity = new DataUnity(container);
            var unity = new EngineUnityContainer(container);
            dataUnity.Resolve();
            unity.Resolve();
            var engine = container.GetInstance<StartEngine.StartEngine>();
            engine.Run();
        }
    }
}
