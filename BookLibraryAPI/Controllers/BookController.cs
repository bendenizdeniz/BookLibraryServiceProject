using Business.Business;
using Business.Interfaces;
using Entity.Entity;
using Entity.Modals.APIRequestModals;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookController : ControllerBase
    {
        private readonly IBookManager bookManager;

        public BookController(IBookManager bookManager)
        {
            this.bookManager = bookManager;
        }

        [HttpGet("GetBook")]
        public async Task<Book> GetBook([FromQuery] GetBookRequestModal bookRequest)
        {
            return await bookManager.GetBook(bookRequest);
        }

        [HttpPost("CreateBook")]
        public async Task<Book> CreateBook(CreateBookRequestModal bookRequestModal)
        {
            return await bookManager.CreateBook(bookRequestModal);
        }

        [HttpDelete("DeleteBook")]
        public async Task DeleteBook([FromQuery] DeleteBookRequestModal bookRequestModal)
        {
            await bookManager.DeleteBook(bookRequestModal);
        }

        [HttpGet("GetBookByAuthor")]
        public async Task<Book> GetBookByAuthor([FromQuery] GetBookByAuthorRequestModal bookRequestModal)
        {
            return await bookManager.GetBookByAuthor(bookRequestModal);
        }

        [HttpGet("GetBookByOwner")]
        public async Task<Book> GetBookByOwner([FromQuery] GetBookByOwnerRequestModal bookRequestModal)
        {
            return await bookManager.GetBookByOwner(bookRequestModal);
        }

        [HttpGet("GetBookByName")]
        public async Task<Book> GetBookByName([FromQuery] GetBookByNameRequestModal bookRequestModal)
        {
            return await bookManager.GetBookByName(bookRequestModal);
        }

        [HttpPut("RemoveOwnerFromBook")]
        public async Task<Book> RemoveOwnerFromBook([FromQuery] RemoveOwnerFromBookRequestModal bookRequestModal)
        {
            return await bookManager.RemoveOwnerFromBook(bookRequestModal);
        }

        [HttpPut("InsertOwnerToBook")]
        public async Task<Book> InsertOwnerToBook([FromQuery] InsertOwnerToBookRequestModal bookRequestModal)
        {
            return await bookManager.InsertOwnerToBook(bookRequestModal);
        }
    }
}
