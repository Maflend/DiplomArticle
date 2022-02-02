namespace AuthenticationBlazor.Server.Services.ProductService
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();
    }
}
