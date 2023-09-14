using BookLibraryAPI.Models.APIRequestModels;
using Entity.Entity;
using Entity.Modals.APIRequestModals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ILibraryCenterManager
    {
        public Task<LibraryCenter> CreateLibraryCenter(CreateLibraryCenterRequestModal libraryCenter);

        public Task<LibraryCenter> GetLibraryCenter(GetLibraryCenterRequestModal libraryCenterRequest);

        public void DeleteLibraryCenter(DeleteLibraryCenterRequestModal libraryCenterRequest);

        public Task<List<Book>> GetAllBooks(GetAllBooksLibraryCenterRequestModal libraryCenterRequest);
    }
}
