using AutoMapper;
using Catalog.API.DTOs;
using Catalog.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/catalog")]
    public class CatalogController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public CatalogController(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        [HttpGet("{bookId}/info")]
        public async Task<ActionResult<BookInfoDto>> getBookById(int bookId)
        {
            var book = await _bookRepository.GetBookByIdAsync(bookId);
            var bookDto = _mapper.Map<IEnumerable<BookInfoDto>>(book);
            return Ok(bookDto);
        }

        [HttpGet("{bookTopic}/search")]
        public async Task<ActionResult<BookSearchDto>> getBookByName(string bookTopic)
        {
            var book = await _bookRepository.GetBookByTopicAsync(bookTopic);
            var bookDto = _mapper.Map<IEnumerable<BookSearchDto>>(book);
            return Ok(bookDto);
        }

        [HttpPost("{bookId}/purchase")]
        public async Task<ActionResult> PurchaseBook(int bookId)
        {
            var response = await _bookRepository.PurchaseBook(bookId);
            if (response)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
            
        }
    }
}
