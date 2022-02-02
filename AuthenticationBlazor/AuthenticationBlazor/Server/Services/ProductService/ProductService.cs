using AuthenticationBlazor.Server.Services.DataBase;

namespace AuthenticationBlazor.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IData _data;

        public ProductService(IData data)
        {
            _data = data;
        }
        public async Task<List<Product>> GetProducts()
        {
            if(_data.Products is null)
            {
                throw new Exception("Нет продуктов");
            }
            return _data.Products;
        }
    }
}
