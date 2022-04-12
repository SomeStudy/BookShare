using BookShare.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookShare.Api.BLL.Services.Abstract
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetBooks();

        Task<Book> GetBookById(Guid Id);

        ///what's the best practise for update and post service methods?

    }
}
