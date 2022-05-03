using BookShare.Api.DAL.Abstract;
using BookShare.Api.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Core;
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
            new Book { Id = Guid.Parse("02593F89-E28E-4D7C-AF23-8F6C9D5FCF8B"),Name = "Book55555"  }};


        public async Task<Book> GetBookById(Guid Id)
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            IMongoDatabase db = client.GetDatabase("BookShare");
            Book book = new Book
            {
               Id = new Guid(),
               Name = "Adventures of Mowgli"

            };
            var collection = db.GetCollection<Book>("books");

            await collection.InsertOneAsync(book);

            var result = await collection.FindAsync(_ => _.Name == "Adventures of Mowgli");

            //var result = await Task.FromResult<Book>(Books.FirstOrDefault(x => x.Id == Id));

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            var result = await Task.FromResult<IEnumerable<Book>>(Books);

            return result;
        }
    }
}
