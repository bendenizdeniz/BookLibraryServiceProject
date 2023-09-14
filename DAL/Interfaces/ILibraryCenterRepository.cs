using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ILibraryCenterRepository
    {
        public Task<LibraryCenter> CreateLibraryCenter(LibraryCenter libraryCenter);

        public Task<LibraryCenter> GetLibraryCenter(int id);

        public Task DeleteLibraryCenter(int id);
    }
}
