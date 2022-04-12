using BookShare.Api.DAL.Abstract;
using BookShare.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShare.Api.DAL.Concrete
{
    public class BookRepository : IBookRepository
    {
        private static List<Book> Books { get; set; } = new List<Book> {

            new Book { Id = Guid.Parse("27B5A833-12C3-4CD5-93FE-EEDC76F403C8"),Name = "Book1"  },
            new Book { Id = Guid.Parse("02593F89-E28E-4D7C-AF23-8F6C9D5FCF8B"),Name = "Book2"  }};


        public async Task<Book> GetBookById(Guid Id)
        {
            var result = await Task.FromResult<Book>(Books.FirstOrDefault(x => x.Id == Id));

            return result;
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            var result = await Task.FromResult<IEnumerable<Book>>(Books);

            return result;
        }
    }
}
