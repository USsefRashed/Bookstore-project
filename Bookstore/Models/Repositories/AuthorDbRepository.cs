using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models.Repositories
{
    public class AuthorDbRepository:IBookstoreRepository<Author>
    {
        BookstoreDbContext db;
        public AuthorDbRepository(BookstoreDbContext _db)
        {
            db = _db;
        }
        public void Add(Author entity)
        {
            db.Authors.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var Target = Find(id);
            db.Authors.Remove(Target);
            db.SaveChanges();
        }

        public Author Find(int id)
        {
            var Target = db.Authors.SingleOrDefault(b => b.Id == id);
            return Target;
        }

        public List<Author> List()
        {
            return db.Authors.ToList();
        }

        public List<Author> Search(string term)
        {
           return db.Authors.Where(a => a.FullName.Contains(term)).ToList();

        }

        public void Update(int id, Author entity)
        {
            db.Update(entity);
            db.SaveChanges();
        }
    }
}
