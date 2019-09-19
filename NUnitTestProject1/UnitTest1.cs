using NUnit.Framework;
using WebApplication1.Models;
using System.Collections.Concurrent;
using Moq;
using System.Collections.Generic;
using Books.Controllers;

namespace Tests
{
    public class Tests
    {
     

        [Test]
        public void AddTest()
        {  //Arrange

            Book item = new Book();
            ConcurrentDictionary<string, Book> _books =
              new ConcurrentDictionary<string, Book>();
            //Act
            item.Id = System.Guid.NewGuid().ToString();
            _books[item.Id] = item;
            //Assert
            Assert.IsNotEmpty(_books);
        }
        [Test]
        public void FindTest()
        {
            //Arrange
            Book item = new Book();
            ConcurrentDictionary<string, Book> _books =
              new ConcurrentDictionary<string, Book>();
            item.Id = "11";
            _books[item.Id] = item;
            Book finded_item = new Book();

            //Act
            _books.TryGetValue("11", out finded_item);

            //Assert
            Assert.AreEqual(item.Id, finded_item.Id);
        }
           

        
        [Test]
        public void RemoveTest()
        {  //Arrange
            Book item = new Book();
            ConcurrentDictionary<string, Book> _books =
              new ConcurrentDictionary<string, Book>();
            item.Id = "11";
            _books[item.Id] = item;

            //Act
            _books.TryRemove("11", out item);
            //Assert
            Assert.IsEmpty(_books);
        }

        [Test]
        public void Test()
        {
            var mock = new Mock<IInMemoryRepository>();
            _ = mock.Setup(a => a.GetAll()).Returns( new List<Book>());
            BooksController controller = new BooksController(mock.Object);

            // Act
            List result = controller.GetAll() as List;

            // Asserts
            Assert.IsNotNull(result);

        }
        
    }
}