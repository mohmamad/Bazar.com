using Bazar.com.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Bazar.com.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class FrontendController : Controller
    {
        private readonly HttpClient _httpClient;
        public FrontendController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }
        [HttpGet("{bookId}/info")]
        public async Task<ActionResult<BookDto>> GetBookById(int bookId)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"https://localhost:7093/api/catalog/{bookId}/info");

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    return Ok(responseBody);
                }
                else
                {
                    return StatusCode((int)response.StatusCode, "Error occurred while calling the external API.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
           
        }

        [HttpGet("{bookTopic}/search")]
        public async Task<ActionResult<BookDto>> GetBookByName(string bookTopic)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"https://localhost:7093/api/catalog/{bookTopic}/search");

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    return Ok(responseBody);
                }
                else
                {
                    return StatusCode((int)response.StatusCode, "Error occurred while calling the external API.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
            return Ok();
        }

        [HttpPost("{bookId}/Order")]
        public async Task<ActionResult<BookDto>> OrderBookById(int bookId)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsync($"https://localhost:7151/api/book/{bookId}/purchase\r\n",null);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    return Ok(responseBody);
                }
                else
                {
                    return StatusCode((int)response.StatusCode, "Error occurred while calling the external API.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
            return Ok();
        }
    }
}
