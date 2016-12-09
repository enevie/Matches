using System.Configuration;
using DataAccessLayer.Repository;
using MongoDB.Driver;
using SimpleInjector;

namespace DataAccessLayer.Unity
{
    public class DataUnity
    {
        private readonly Container _container;

        public DataUnity(Container container)
        {
            _container = container;
        }

        public void Resolve()
        {
            _container.Register(() => new MongoClient(ConfigurationManager.ConnectionStrings["MongoDb"].ConnectionString).GetDatabase("Matches"));
            _container.Register(typeof(IDocumentRepository<>), typeof(DocumentRepository<>));
        }
    }
}
