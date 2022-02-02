using AuthenticationBlazor.Shared;
using System.Net.Http.Json;

namespace AuthenticationBlazor.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;
        public string ErrorMessage { get; set; } = string.Empty;
        public ProductService(HttpClient http)
        {
            _http = http;
        }
        public async Task<List<Product>> GetProducts()
        {
            var response = await _http.GetAsync("api/product");
            var desegializingResponse = await response.Content.ReadFromJsonAsync<ServerResponse<List<Product>>>();
            if(!desegializingResponse.Success)
            {
                ErrorMessage = desegializingResponse.Message;
                return new();
            }
            return desegializingResponse.Data;
        }
    }
}
