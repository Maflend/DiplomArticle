using AuthenticationBlazor.Server.Services.ProductService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet()][Authorize]
        public async Task<ActionResult<ServerResponse<List<Product>>>> GetAll()
        {
            try
            {
                var serviceResponse = await _productService.GetProducts();
                return Ok(new ServerResponse<List<Product>> { Data = serviceResponse , Success = true });
            }
            catch(Exception ex)
            {
                return BadRequest(new ServerResponse<List<Product>> { Message = ex.Message, Success = false });
            }
           
        }
    }
}
