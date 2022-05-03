using BookShare.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookShare.Api.DAL.Abstract
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooks();

        Task<Book> GetBookById(Guid Id);

        
    }
}
