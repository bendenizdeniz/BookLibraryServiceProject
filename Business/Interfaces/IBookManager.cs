using Entity.Entity;
using Entity.Modals.APIRequestModals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IBookManager
    {
        public Task<Book> CreateBook(CreateBookRequestModal bookRequestModal);

        public Task<Book> GetBook(GetBookRequestModal bookRequest);

        public Task DeleteBook(DeleteBookRequestModal bookRequestModal);

        public Task<Book> GetBookByAuthor(GetBookByAuthorRequestModal bookRequestModal);

        public Task<Book> GetBookByOwner(GetBookByOwnerRequestModal bookRequestModal);

        public Task<Book> GetBookByName(GetBookByNameRequestModal bookRequestModal);

        public Task<Book> RemoveOwnerFromBook(RemoveOwnerFromBookRequestModal bookRequestModal);

        public Task<Book> InsertOwnerToBook(InsertOwnerToBookRequestModal bookRequestModal);
    }
}
