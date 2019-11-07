using System.Collections.Generic;
using System.Threading.Tasks;
using Alligator.Domain.Model;

namespace Alligator.Persistence.Contract
{
    public interface IBookService
    {
        Task<Book> Create(Book book);
        Task<List<Book>> Get();
        Task<Book> Get(string id);
        Task Remove(Book bookIn);
        Task Remove(string id);
        Task Update(string id, Book bookIn);
    }
}