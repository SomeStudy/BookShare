using BookShare.Api.BLL.Services.Abstract;
using BookShare.Api.DAL.Abstract;
using BookShare.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookShare.Api.BLL.Services.Concrete
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;

        public BookService(IBookRepository _bookRepository)
        {
            bookRepository = _bookRepository;
        }

        public async Task<Book> GetBookById(Guid Id)
        {
            return await bookRepository.GetBookById(Id);
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await bookRepository.GetBooks();
        }
    }
}
