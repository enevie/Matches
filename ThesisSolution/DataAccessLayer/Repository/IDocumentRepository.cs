using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using DataAccessLayer.Models.Contract;

namespace DataAccessLayer.Repository
{
    public interface IDocumentRepository<TDocument> where TDocument : IDocument
    {
        Task Add(TDocument model);
        Task AddBatch(IEnumerable<TDocument> models);
        Task<TDocument> Get(string id);
        IQueryable<TDocument> Query();
        Task Remove(string id);
        Task RemoveBatch(IEnumerable<string> models);
        Task Update(TDocument model);
        Task Upsert(TDocument model);
    }
}
