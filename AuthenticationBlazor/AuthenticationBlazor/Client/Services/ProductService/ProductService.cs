using AuthenticationBlazor.Client.Services.AuthService;
using AuthenticationBlazor.Shared;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace AuthenticationBlazor.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;
        private readonly IAuthService _authService;

        public string ErrorMessage { get; set; } = string.Empty;
        public ProductService(HttpClient http, IAuthService authService)
        {
            _http = http;
            _authService = authService;
        }
        public async Task<List<Product>> GetProducts()
        {
            var token = await _authService.GetToken();
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
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
