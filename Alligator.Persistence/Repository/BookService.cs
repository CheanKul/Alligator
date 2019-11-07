using Alligator.Domain.Model;
using Alligator.Persistence;
using Alligator.Persistence.Contract;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alligator
{
    public class BookService : IBookService
    {
        private readonly IMongoDbContext context;

        public BookService(IMongoDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Book>> Get()=>
            await context.Books.Find(book => true).ToListAsync();
        


        public async Task<Book> Get(string id) =>
            await context.Books.Find<Book>(book => book.Id == id).FirstOrDefaultAsync();

        public async Task<Book> Create(Book book)
        {
            await context.Books.InsertOneAsync(book);
            return book;
        }

        public async Task Update(string id, Book bookIn) =>
            await context.Books.ReplaceOneAsync(book => book.Id == id, bookIn);

        public async Task  Remove(Book bookIn) =>
            await context.Books.DeleteOneAsync(book => book.Id == bookIn.Id);

        public async Task Remove(string id) =>
            await context.Books.DeleteOneAsync(book => book.Id == id);
    }
}