using Business.Interfaces;
using DAL.DataAccess;
using DAL.Interfaces;
using Entity.Entity;
using Entity.Modals.APIRequestModals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business
{
    public class BookManager : IBookManager
    {
        private readonly IBookRepository bookRepository;

        public BookManager(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task<Book> CreateBook(CreateBookRequestModal bookRequestModal)
        {
            Book book = new Book();
            Guid randomGuid = Guid.NewGuid();
            byte[] bytes = randomGuid.ToByteArray();
            var intId = BitConverter.ToInt32(bytes, 0);

            book.Id = intId < 0 ? -intId : intId;
            book.LibraryId = bookRequestModal.LibraryId;
            book.PageNumber = bookRequestModal.PageNumber;
            book.Author = bookRequestModal.Author;
            book.PageNumber = bookRequestModal.PageNumber;
            book.Name = bookRequestModal.Name;
            book.Category = bookRequestModal.Category;
            book.CreatedTime = DateTime.Now.ToUniversalTime();

            var _book = await bookRepository.CreateBook(book);
            if (_book == null)
            {
                throw new InvalidOperationException("Identified Book has not found.");
            }
            return _book;
        }

        public async Task DeleteBook(DeleteBookRequestModal bookRequestModal)
        {
            GetBookRequestModal getBookRequestModal = new GetBookRequestModal();
            getBookRequestModal.BookId = bookRequestModal.BookId;
            Book book = await GetBook(getBookRequestModal);
            await bookRepository.DeleteBook(book);
        }

        public async Task<Book> GetBook(GetBookRequestModal bookRequest)
        {
            var _book = await bookRepository.GetBook(bookRequest.BookId);
            if (_book == null)
            {
                throw new InvalidOperationException("Identified Book has not found.");
            }
            return _book;
        }

        public async Task<Book> GetBookByAuthor(GetBookByAuthorRequestModal bookRequestModal)
        {
            Book book = await bookRepository.GetBookByAuthor(bookRequestModal.Author);
            if (book == null)
            {
                throw new InvalidOperationException("Identified Book has not found.");
            }
            return book;
        }

        public async Task<Book> GetBookByName(GetBookByNameRequestModal bookRequestModal)
        {
            Book _book = await bookRepository.GetBookByName(bookRequestModal.BookName);
            if (_book == null)
            {
                throw new InvalidOperationException("Identified Book has not found.");
            }
            return _book;
        }

        public async Task<Book> GetBookByOwner(GetBookByOwnerRequestModal bookRequestModal)
        {
            Book _book = await bookRepository.GetBookByOwner(bookRequestModal.CustomerId);
            if (_book == null)
            {
                throw new InvalidOperationException("Identified Book has not found.");
            }
            return _book;
        }

        public async Task<Book> InsertOwnerToBook(InsertOwnerToBookRequestModal bookRequestModal)
        {
            Book book = await bookRepository.GetBook(bookRequestModal.BookId);
            book.CustomerId = bookRequestModal.CustomerId;
            book.UpdatedTime = DateTime.UtcNow;
            return await bookRepository.UpdateBook(book);
        }

        public async Task<Book> RemoveOwnerFromBook(RemoveOwnerFromBookRequestModal bookRequestModal)
        {
            Book book = await bookRepository.GetBook(bookRequestModal.BookId);
            book.CustomerId = null;
            book.UpdatedTime = DateTime.UtcNow;
            return await bookRepository.UpdateBook(book);
        }
    }
}
