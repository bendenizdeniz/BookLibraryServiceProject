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
    public class LibraryCenterRepository : ILibraryCenterRepository
    {
        private readonly BookLibraryContext context;

        public LibraryCenterRepository(BookLibraryContext _context)
        {
            this.context = _context;
        }

        public async Task<LibraryCenter> CreateLibraryCenter(LibraryCenter libraryCenter)
        {
            await context.LibraryCenters.AddAsync(libraryCenter);
            await context.SaveChangesAsync();
            return libraryCenter;
        }

        public async Task DeleteLibraryCenter(int id)
        {
            var _libraryCenter = await context.LibraryCenters.FirstOrDefaultAsync(x => x.Id == id);

            if (_libraryCenter == null)
            {
                throw new InvalidOperationException("Identified LibraryCenter has not been found.");
            }

            context.LibraryCenters.Remove(_libraryCenter);
            await context.SaveChangesAsync();
        }

        public async Task<LibraryCenter> GetLibraryCenter(int id)
        {
            var libraryCenter = await context.LibraryCenters.FirstOrDefaultAsync(x => x.Id == id);
            if (libraryCenter == null)
            {
                throw new InvalidOperationException("Identified LibraryCenter has not found.");
            }
            return libraryCenter;
        }
    }
}
