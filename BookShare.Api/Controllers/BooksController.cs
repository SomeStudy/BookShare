using BookShare.Api.BLL.Services.Abstract;
using BookShare.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookShare.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService bookService;

        public BooksController(IBookService _bookService)
        {
            bookService = _bookService;
        }

        // GET: api/books
        // GET: api/v1.0/books
        // GET: api/v2.0/books
        //[MapToApiVersion("1.0")]
        //[MapToApiVersion("2.0")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await bookService.GetBooks());
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await bookService.GetBookById(id));
        }

        //// POST api/<BooksController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<BooksController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<BooksController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
