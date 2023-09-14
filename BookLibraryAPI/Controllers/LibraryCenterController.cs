using BookLibraryAPI.Models.APIRequestModels;
using Business.Interfaces;
using Entity.Entity;
using Entity.Modals.APIRequestModals;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryCenterController : ControllerBase
    {
        private readonly ILibraryCenterManager libraryCenterManager;

        public LibraryCenterController(ILibraryCenterManager libraryCenterManager)
        {
            this.libraryCenterManager = libraryCenterManager;
        }

        [HttpGet("GetLibraryCenter")]
        public async Task<LibraryCenter> GetLibraryCenter([FromQuery] GetLibraryCenterRequestModal libraryCenterRequest)
        {
            return await libraryCenterManager.GetLibraryCenter(libraryCenterRequest);
        }

        [HttpPost("CreateLibraryCenter")]
        public async Task<LibraryCenter> CreateLibraryCenter(CreateLibraryCenterRequestModal libraryCenter)
        {
            return await libraryCenterManager.CreateLibraryCenter(libraryCenter);
        }

        [HttpDelete("DeleteLibraryCenter")]
        public void DeleteLibraryCenter([FromQuery] DeleteLibraryCenterRequestModal libraryCenter)
        {
            libraryCenterManager.DeleteLibraryCenter(libraryCenter);
        }

        [HttpGet("GetAllBooks")]
        public async Task<List<Book>> GetAllBooks([FromQuery] GetAllBooksLibraryCenterRequestModal libraryCenter)
        {
            return await libraryCenterManager.GetAllBooks(libraryCenter);
        }
    }
}
