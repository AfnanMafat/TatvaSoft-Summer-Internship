using BooksApi.Entities.Entities;
using BooksApi.Models;
using BooksApi.Services;
using BooksApi.Services.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService) 
        {
            _bookService = bookService;
        }

        [HttpPost]
        [Route("Add")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> AddBook(BookDetails bookDetails)
        {
            await _bookService.InsertBook(bookDetails);
            return Ok("Book created !");
        }

        //[HttpPost]
        //[Route("Edit")]
        //[Authorize(Roles = "admin,manager")]
        //public async Task<ActionResult> EditBook(BookDetails bookDetails)
        //{
        //    // Forbid()
        //    return Ok("Book updated !");
        //}

        //[HttpGet]
        //[Route("GetAll")]
        //public ActionResult GetAll()
        //{
        //    return Ok(_bookService.GetAll());
        //}

        //[HttpGet]
        //[Route("GetById")]
        //public ActionResult GetById(int id)
        //{
        //    var res = _bookService.GetBookDetailsById(id);

        //    if (res != null) { return Ok(res); }

        //    return NotFound("Book not found!");
        //}

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<List<BookDetails>> GetAll()
        {
            var allBooks = _bookService.GetAll();
            return Ok(allBooks);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public ActionResult<BookDetails> GetById(int id)
        {
            var res = _bookService.GetBookDetailsById(id);

            if (res != null)
                return Ok(res);

            return NotFound("Book not found!");
        }

        // To Update Book
        // To Delete Book

        [HttpPut]
        [Route("Edit/{id}")]
        [Authorize(Roles = "admin,manager")]
        public ActionResult EditBook(int id, BookDetails bookDetails)
        {
            if (id != bookDetails.Id)
            {
                return BadRequest("ID in URL does not match ID in payload.");
            }

            var existing = _bookService.GetBookDetailsById(id);
            if (existing == null)
            {
                return NotFound("Book not found!");
            }

            _bookService.UpdateBook(bookDetails);
            return Ok("Book updated!");
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteBook(int id)
        {
            var existing = _bookService.GetBookDetailsById(id);
            if (existing == null)
            {
                return NotFound("Book not found!");
            }

            _bookService.DeleteBook(id);
            return Ok("Book deleted!");
        }
    }
}
