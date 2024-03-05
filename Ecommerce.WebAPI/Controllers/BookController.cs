using Microsoft.AspNetCore.Mvc;
using Ecommerce.Application.Services;
using System.Threading.Tasks;
using Ecommerce.Dtos.Author;
using Microsoft.AspNetCore.Authorization;
using Ecommerce.Dtos.Book;

namespace Ecommerc.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IAuthorServices _AuthorService;

        public BookController(IBookService bookService, IAuthorServices authorService)
        {
            _bookService = bookService;
            _AuthorService = authorService;
        }

        // GET: api/Book
        [HttpGet]
        public async Task<IActionResult> Get(int items, int pagenumber)
        {
            var result = await _bookService.GetAllPagination(items, pagenumber);
            return Ok(result);
        }

        // GET: api/Book/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _bookService.GetOne(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // POST: api/Book
        [HttpPost]
        public async Task<IActionResult> Create(BookCreateViewModel book)
        {
            if (ModelState.IsValid)
            {
                var result = await _bookService.Create(book);
                if (result.IsSuccess)
                {
                    return CreatedAtAction(nameof(GetById), new { id = result.Entity.Title}, result.Entity.Title);
                }
                return BadRequest(result.Message);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Book/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BookEditViewModel book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var result = await _bookService.Edit(book);
                if (result.IsSuccess)
                {
                    return NoContent();
                }
                return BadRequest(result.Message);
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/Book/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _bookService.GetOne(id);
            if (book == null)
            {
                return NotFound();
            }

            var result = await _bookService.HardDelete(id);
            if (result.IsSuccess)
            {
                return NoContent();
            }
            return BadRequest(result.Message);
        }
    }
}
