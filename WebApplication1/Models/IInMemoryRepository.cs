using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public interface IInMemoryRepository
    {
        void Add(Book item);
        IEnumerable<Book> GetAll();
        Book Find(string id);
        Book Remove(string id);
        void Update(Book item);
    }
}
