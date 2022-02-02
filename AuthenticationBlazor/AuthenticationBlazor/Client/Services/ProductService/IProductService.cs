using AuthenticationBlazor.Shared;

namespace AuthenticationBlazor.Client.Services.ProductService
{
    public interface IProductService
    {
        string ErrorMessage { get; set; }
        Task<List<Product>> GetProducts();
    }
}
