using Microsoft.AspNetCore.Mvc;
using mybooks.Data.Services;
using mybooks.Data.ViewModels;

namespace mybooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        public AuthorsService _authorService;

        public AuthorController(AuthorsService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody] AuthorVM authorVM)
        {
            _authorService.AddAuthor(authorVM);

            return Ok();
        }

        [HttpGet("get-author-with-books/{id}")]
        public IActionResult GetAuthorWithBooks(int id)
        {
            var response = _authorService.GetAuthorWitBooks(id);
            return Ok(response);
        }
    }
}
