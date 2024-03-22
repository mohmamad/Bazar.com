using Microsoft.AspNetCore.Mvc;
using Order.DataAccess.Interfaces;
using System.Net.Http;

namespace Order.API.Controllers
{
    [ApiController]
    [Route("api/book/{bookId}/purchase")]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly HttpClient _httpClient;

        public OrderController(IOrderRepository orderRepository, IHttpClientFactory httpClientFactory)
        {
            _orderRepository = orderRepository;
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpPost]
        public async Task<ActionResult> Order(int bookId)
        {
            var IsOrdered = await _orderRepository.PurchaseBook(bookId);
            if (IsOrdered)
            {

                try
                {
                    HttpResponseMessage response = await _httpClient.PostAsync($"https://localhost:7093/api/catalog/{bookId}/purchase",null);

                    if (response.IsSuccessStatusCode)
                    {
                        return Ok();
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
            else
            {
                return BadRequest("this book is out of stock.");
            }
            
        }
    }
}
