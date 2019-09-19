using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Swashbuckle.AspNetCore.Swagger;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Books.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {       
   
            public BooksController(IInMemoryRepository bookItems)
            {
                BookItems = bookItems;
            }
            public IInMemoryRepository BookItems { get; set; }

        [HttpGet]
        public IEnumerable<Book> GetAll()
        {
            return BookItems.GetAll();
        }

        [HttpGet("{id}", Name = "GetBook")]
        public IActionResult GetById(string id)
        {
            var item = BookItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Book item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            BookItems.Add(item);
            return CreatedAtRoute("GetBook", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Book item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var book = BookItems.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            BookItems.Update(item);
         
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var book = BookItems.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            BookItems.Remove(id);
            return new NoContentResult();
        }
    }
}
