using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
//using MandatoryAssignment2RestService.Dll;
using MandatoryAssigment1Library;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MandatoryAssignment2RestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public static List<Book> Repo = new List<Book>()
        {
            new Book(){Title = "The Fellowship of the Ring: Being the First Part of The Lord of the Rings", Author="J.R.R. Tolkien",NoOfPages=432 ,ISBN13="978-0547928210" },
            new Book(){Title = "The Two Towers: Being the Second Part of The Lord of the Rings", Author="J.R.R. Tolkien",NoOfPages=352 ,ISBN13="978-0547928203" },
            new Book(){Title = "The Return of the King: Being the Third Part of the Lord of the Rings", Author="J.R.R. Tolkien",NoOfPages=432 ,ISBN13="978-0547928197" },
            new Book(){Title = "Fight Club: A Novel", Author="Chuck Palahniuk",NoOfPages=224 ,ISBN13="978-0393355949" },
            new Book(){Title = "Dune", Author="Frank Herbert",NoOfPages=704,ISBN13="978-0441013593" },

        };
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return Repo;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{isbn}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<Book> Get(string isbn)
        {
            IEnumerable<Book> res = Repo.Where(x => x.ISBN13 == isbn);
            if (res.Count() == 0) return NoContent();
            Book b = res.FirstOrDefault();
            return b;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post(/*[FromBody]*/ Book newBook)
        {
            Repo.Add(newBook);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{isbn}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Put(string isbn, /*[FromBody]*/ Book updatedBook)
        {
            Book get = Repo.Find(x => x.ISBN13 == isbn);
            //if (get == null) { Console.WriteLine("didn't find the book you wanted to update, check isbn or title and try again"); }
            if (get==null)
            {
                return NoContent();
            }
            get.Author = updatedBook.Author;
            get.Title = updatedBook.Title;
            get.NoOfPages = updatedBook.NoOfPages;
            get.ISBN13 = updatedBook.ISBN13;
            return Ok();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{isbn}")]
        public void Delete(String isbn)
        {
            Repo.Remove(Repo.Find(x => x.ISBN13 == isbn));
        }
    }
}
