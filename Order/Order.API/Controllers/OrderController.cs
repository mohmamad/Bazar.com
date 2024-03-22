using Microsoft.AspNetCore.Mvc;
using Order.DataAccess.Interfaces;

namespace Order.API.Controllers
{
    [ApiController]
    [Route("api/book/{bookId}/purchase")]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost]
        public async Task<ActionResult> Order(int bookId)
        {
            await _orderRepository.PurchaseBook(bookId);
            return Ok();
        }
    }
}
