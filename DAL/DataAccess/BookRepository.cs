using DAL.Interfaces;
using Entity.Context;
using Entity.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess
{
    public class BookRepository : IBookRepository
    {
        private readonly BookLibraryContext context;

        public BookRepository(BookLibraryContext _context)
        {
            this.context = _context;
        }

        public async Task<Book> CreateBook(Book book)
        {
            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
            return book;
        }

        public async Task DeleteBook(Book book)
        {
            context.Books.Remove(book);
            await context.SaveChangesAsync();
        }

        public async Task<Book> GetBook(int id)
        {
            var book = await context.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (book == null)
            {
                throw new InvalidOperationException("Identified Book has not found.");
            }
            return book;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await context.Books.ToListAsync();
        }

        public async Task<Book> GetBookByAuthor(string author)
        {
            Book currentBook = await context.Books.FirstOrDefaultAsync(book => book.Author == author);
            if (currentBook == null)
            {
                throw new InvalidOperationException("Identified Book has not found.");
            }
            return currentBook;
        }

        public async Task<Book> GetBookByOwner(int owner)
        {
            Book currentBook = await context.Books.FirstOrDefaultAsync(book => book.CustomerId == owner);
            if (currentBook == null)
            {
                throw new InvalidOperationException("Identified Book has not found.");
            }
            return currentBook;
        }

        public async Task<Book> GetBookByName(string name)
        {
            Book currentBook = await context.Books.FirstOrDefaultAsync(book => book.Name == name);
            if (currentBook == null)
            {
                throw new InvalidOperationException("Identified Book has not found.");
            }
            return currentBook;
        }

        public async Task<Book> UpdateBook(Book book)
        {
            context.Books.Update(book);
            await context.SaveChangesAsync();
            return book;
        }
    }
}
