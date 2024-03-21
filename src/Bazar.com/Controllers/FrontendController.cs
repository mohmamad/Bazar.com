using Bazar.com.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.com.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class FrontendController : Controller
    {
        public FrontendController()
        {

        }
        [HttpGet("{bookId}/search")]
        public async Task<ActionResult<BookDto>> GetBookById(Guid bookId)
        {
            return Ok();
        }

        [HttpGet("{bookName}/search")]
        public async Task<ActionResult<BookDto>> GetBookByName(string bookName)
        {
            return Ok();
        }

        [HttpPost("{bookId}/Order")]
        public async Task<ActionResult<BookDto>> OrderBookById(string bookName)
        {
            return Ok();
        }
    }
}
