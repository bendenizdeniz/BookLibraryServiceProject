using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IBookRepository
    {
        public Task<Book> CreateBook(Book book);

        public Task<Book> GetBook(int id);

        public Task DeleteBook(Book book);

        public Task<List<Book>> GetAllBooks();

        public Task<Book> GetBookByAuthor(string author);

        public Task<Book> GetBookByOwner(int owner);

        public Task<Book> GetBookByName(string name);

        public Task<Book> UpdateBook(Book book);
    }
}
