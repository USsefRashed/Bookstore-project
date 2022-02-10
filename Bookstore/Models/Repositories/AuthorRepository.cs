using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models.Repositories
{
    public class AuthorRepository : IBookstoreRepository<Author>
    {
        List<Author> authors;
        public AuthorRepository()
        {
            authors = new List<Author>
            {
                new Author{Id=1,FullName="Ramy Khalil"},
                new Author{Id=2,FullName="Yousef Saber"},
                new Author{Id=3,FullName="Mohammed Shady"},

            };
        }
        public void Add(Author entity)
        {
            entity.Id = authors.Max(b => b.Id + 1);
            authors.Add(entity);
        }

        public void Delete(int id)
        {
            var Target = Find(id);
            
            authors.Remove(Target);
        }

        public Author Find(int id)
        {
            var Target = authors.SingleOrDefault(b => b.Id == id);
            return Target;
        }

        public List<Author> List()
        {
            return authors;
        }

        public List<Author> Search(string term)
        {
            return authors.Where(a => a.FullName.Contains(term)).ToList();
        }

        public void Update(int id, Author entity)
        {
            var newAuthor = Find(id);
            newAuthor.Id = entity.Id;
            newAuthor.FullName = entity.FullName;
            
        }
    }
}
