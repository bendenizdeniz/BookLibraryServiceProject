using BookLibraryAPI.Models.APIRequestModels;
using Business.Interfaces;
using DAL.Interfaces;
using Entity.Entity;
using Entity.Modals.APIRequestModals;

namespace Business.Business
{
    public class LibraryCenterManager : ILibraryCenterManager
    {
        private readonly ILibraryCenterRepository libraryCenterRepository;

        public LibraryCenterManager(ILibraryCenterRepository libraryCenterRepository)
        {
            this.libraryCenterRepository = libraryCenterRepository;
        }

        public async Task<LibraryCenter> CreateLibraryCenter(CreateLibraryCenterRequestModal libraryCenter)
        {
            LibraryCenter _libraryCenter = new LibraryCenter();
            Guid randomGuid = Guid.NewGuid();
            byte[] bytes = randomGuid.ToByteArray();
            var intId = BitConverter.ToInt32(bytes, 0);
            _libraryCenter.Id = intId < 0 ? -intId : intId;

            _libraryCenter.CreatedTime = DateTime.Now.ToUniversalTime();
            _libraryCenter.TotalBookNumber = libraryCenter.TotalBooknumber;
            _libraryCenter.BookList = libraryCenter.BookList;

            return await libraryCenterRepository.CreateLibraryCenter(_libraryCenter);
        }

        public void DeleteLibraryCenter(DeleteLibraryCenterRequestModal libraryCenterRequest)
        {
            libraryCenterRepository.DeleteLibraryCenter(libraryCenterRequest.LibraryId);
        }

        public async Task<List<Book>> GetAllBooks(GetAllBooksLibraryCenterRequestModal libraryCenterRequest)
        {
            var libraryCenter = await libraryCenterRepository.GetLibraryCenter(libraryCenterRequest.LibraryCenterId);
            return libraryCenter.BookList;
        }

        public async Task<LibraryCenter> GetLibraryCenter(GetLibraryCenterRequestModal libraryCenterRequest)
        {
            int libraryId = libraryCenterRequest.LibraryId;
            return await libraryCenterRepository.GetLibraryCenter(libraryId);
        }
    }
}