using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mybooks.Data.Services;
using mybooks.Data.ViewModels;

namespace mybooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksService _bookService;

        public BooksController(BooksService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("get-book-by-id/{id}")] 
        public IActionResult GetBook(int id) {
            return Ok(_bookService.GetBook(id));
        }

        [HttpGet("get-all-book")]
        public IActionResult GetAllBooks()
        {
            return Ok(_bookService.GetAllBooks());
        }
         
        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody]BookVM bookVM)
        {
            _bookService.AddBook(bookVM);
            
            return Ok();
        }

        [HttpPut("update-book/{id}")]
        public IActionResult UpdateBookById(int id, [FromBody] BookVM bookVM)
        {
            var updatedBook = _bookService.UpdateBookById(id, bookVM);

            return Ok(updatedBook);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteBook(int id)
        {
            _bookService.DeleteBookId(id);
            return Ok();
        }


    }
}
