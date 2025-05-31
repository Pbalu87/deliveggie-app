using DeliVeggie.Infrastructure.RabbitMQ;
using DeliVeggie.Shared.Models.Requests;
using DeliVeggie.Shared.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliVeggie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IPublisher _publisher;

        public ProductController(IPublisher publisher)
        {
            _publisher = publisher;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var request = new Request<ProductsRequest>() { Data = new ProductsRequest() };
            var data = await _publisher.RequestAsync(request);
            if (!(data is Response<List<ProductResponse>> response))
            {
                return NotFound();
            }
            return Ok(response.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByIdAsync(string id)
        {
            var request = new Request<ProductDetailsRequest>() { Data = new ProductDetailsRequest() { Id = id } };
            var message = await _publisher.RequestAsync(request);
            if (!(message is Response<ProductDetailsResponse> response))
            {
                return NotFound();
            }
            return Ok(response.Data);
        }
    }
}