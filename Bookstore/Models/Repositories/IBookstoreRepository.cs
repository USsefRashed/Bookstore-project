using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models.Repositories
{
    public interface IBookstoreRepository<TEntity>
    {
        List<TEntity> List();
        TEntity Find(int id);
        void Add(TEntity entity);
        void Delete(int id);
        void Update(int id, TEntity entity);
        List<TEntity> Search(string term);
    }
}
