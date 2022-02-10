using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models.Repositories
{
    public class BookRepository : IBookstoreRepository<Book>
    {
        List<Book> books;
        public BookRepository()
        {
            books = new List<Book>
              {
                  new Book{Id=1,Title="Hello CSS",Description="CSS for web design",Author=new Author{ Id=2},ImageUrl="111.png" },
                  new Book{Id=2,Title="Hello Java",Description="Welcome Java",Author=new Author(), ImageUrl="222.jpg" },
                  new Book{Id=3,Title="Hello C#",Description="-- No Caption --",Author=new Author(),ImageUrl="333.png" },
              };
        }
        public void Add(Book entity)
        {
            entity.Id = books.Max(b => b.Id + 1);
            books.Add(entity);
        }

        public void Delete(int id)
        {
            var Target = Find(id);
            books.Remove(Target);
        }

        public Book Find(int id)
        {
            var Target = books.SingleOrDefault(b => b.Id == id);
            return Target;
        }

        public List<Book> List()
        {
            return books;
        }

        public List<Book> Search(string term)
        {
            return books.Where(b => b.Title.Contains(term)).ToList();
        }

        public void Update(int id, Book entity)
        {
            var newBook = Find(id);
            newBook.Id = entity.Id;
            newBook.Title = entity.Title;
            newBook.Description = entity.Description;
            newBook.Author = entity.Author;
            newBook.ImageUrl = entity.ImageUrl;
        }
    }
}
