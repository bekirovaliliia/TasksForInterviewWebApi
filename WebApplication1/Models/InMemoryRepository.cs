using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using WebApplication1.Models;

namespace Books.Models
{
    public class InMemoryRepository : IInMemoryRepository
    {
        private static ConcurrentDictionary<string, Book> _books =
              new ConcurrentDictionary<string, Book>();

        public InMemoryRepository()
        {
            Add(new Book { Title = "1984", Author = "George Orwell"});
            Add(new Book { Title = "Idiot", Author = "Fedor Dostoyevskii" });
            Add(new Book { Title = "The Little Prince", Author = "Antoine Exupery" });
        }

        public IEnumerable<Book> GetAll()
        {
            return _books.Values;
        }

        public void Add(Book item)
        {
            item.Id = Guid.NewGuid().ToString();
           _books[item.Id] = item;
        }

        public Book Find(string id)
        {
            Book item;
            _books.TryGetValue(id, out item);
            return item;
        }

        public Book Remove(string id)
        {
             Book item;
            _books.TryRemove(id, out item);
            return item;
        }

        public void Update(Book item)
        {
            _books[item.Id] = item;
        }
    }
}
