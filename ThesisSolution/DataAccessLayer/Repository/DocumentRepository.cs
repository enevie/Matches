using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Models.Contract;
using MongoDB.Driver;
using MongoDB.Bson;

namespace DataAccessLayer.Repository
{
    public class DocumentRepository<TDocument> : IDocumentRepository<TDocument> where TDocument : class, IDocument
    {
        private readonly IMongoDatabase _database;

        public DocumentRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public Task Add(TDocument model)
        {
            var task = _database.GetCollection<TDocument>(typeof(TDocument).Name).InsertOneAsync(model);
            task.Wait();
            return task;
        }

        public Task AddBatch(IEnumerable<TDocument> models)
        {
            Task task = _database.GetCollection<TDocument>(typeof(TDocument).Name).InsertManyAsync(models);
            task.Wait();
            return task;
        }

        public Task<TDocument> Get(string id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TDocument> Query()
        {
            throw new NotImplementedException();
        }

        public Task Remove(string id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveBatch(IEnumerable<string> models)
        {
            throw new NotImplementedException();
        }

        public Task Update(TDocument model)
        {
            throw new NotImplementedException();
        }

        public Task Upsert(TDocument model)
        {
            var collection = _database.GetCollection<TDocument>(typeof(TDocument).Name);
            var searchModel = collection.Find(a => a.Id == model.Id).FirstOrDefault();
            if (searchModel != null)
            {
                var task = collection.ReplaceOneAsync(a => a.Id == model.Id, model, new UpdateOptions { IsUpsert = true });
                task.Wait();
                return task;
            }
            else
            {
                var task = collection.InsertOneAsync(model);
                task.Wait();
                return task;
            }
        }
    }
}
